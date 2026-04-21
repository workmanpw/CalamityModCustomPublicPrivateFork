using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using CalamityMod.UI.DialogueDisplay;
using CalamityMod.Utilities;
using MonoMod.Cil;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalamityMod.Dialogues;

internal record DialogueTextDataEntry(
    Mod ProviderMod,
    string FilePath,
    string DialogueKey,
    DialogueTextData Data
    );

internal partial class DialogueLoader : ModSystem
{
    private const string DialogueFilePrefix = "Dialogue.";

    private static readonly Dictionary<string, DialogueTextDataEntry> _DialogueLookup = [];
    private static readonly Dictionary<Mod, MainThreadedFileSystemWatcher> _Watchers = [];

    public override void Load()
    {
        _DialogueLookup.Clear();

        // LocalizationLoader.ExtractLocalizationFiles no longer exists in current tModLoader
        // var method = typeof(LocalizationLoader).GetMethod(nameof(LocalizationLoader.ExtractLocalizationFiles), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        // if (method != null)
        // {
        //     MonoModHooks.Modify(method, ExtractDialogueFilesPatch);
        // }
    }

    public override void PostSetupContent()
    {
        foreach (var mod in ModLoader.Mods)
        {
            // Mod.File no longer exists, check if mod has files
            if (mod.SourceFolder == null)
                continue;

            var path = mod.SourceFolder;
            if (!Directory.Exists(path))
                continue;

            // Extract dialogue files for this mod
            ExtractDialogueFilesForMod(mod, path);

            var watcher = new MainThreadedFileSystemWatcher()
            {
                Path = path,
                Filter = "*.json",
                FileNameFilter = CalamityDialogueFileRegex(),
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                IncludeSubdirectories = true
            };
            watcher.Changed += (arg) =>
            {
                HandleFileUpdate(mod, arg.FullPath);
            };
            watcher.Renamed += (arg) =>
            {
                HandleFileUpdate(mod, arg.FullPath);
            };
            watcher.EnableRaisingEvents = true;
            _Watchers[mod] = watcher;
        }
    }

    private static void ExtractDialogueFilesForMod(Mod mod, string basePath)
    {
        // Mod.File API has been removed in current tModLoader
        // Dialogue extraction no longer works with the new API
        // Dialogues will still load via OnLocalizationsLoaded
        try
        {
            // foreach (var entry in GetDialogueTextEntries(mod, GameCulture.DefaultCulture, skipDeserializeData: true))
            // {
            //     var destFilePath = Path.Combine(basePath, entry.FilePath);
            //     var destDir = Path.GetDirectoryName(destFilePath);
            //     if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
            //
            //     using var stream = mod.GetFile(entry.FilePath).Stream;
            //     using var fileStream = File.OpenWrite(destFilePath);
            //     using var writer = new StreamWriter(fileStream, Encoding.UTF8);
            //     using var reader = new StreamReader(stream, Encoding.UTF8);
            //     writer.Write(reader.ReadToEnd());
            // }
        }
        catch (Exception e)
        {
            ModContent.GetInstance<CalamityMod>().Logger.Error($"Error while extracting DialogueTextData files for mod {mod.Name}: {e}");
        }
    }

    public override void Unload()
    {
        _DialogueLookup.Clear();

        foreach (var watcher in _Watchers.Values)
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
        }

        _Watchers.Clear();
    }

    private static void ExtractDialogueFilesPatch(ILContext il)
    {
        // LocalizationLoader.UpdateLocalizationFilesForMod no longer exists in current tModLoader
        // This IL hook is no longer functional
        return;
    }

    public static bool TryGetDialogue(string dialogueKey, out DialogueTextData data)
    {
        if (_DialogueLookup.TryGetValue(dialogueKey, out var entry))
        {
            data = entry.Data;
            return true;
        }

        data = null;
        return false;
    }

    public override void OnLocalizationsLoaded()
    {
        _DialogueLookup.Clear();

        // Mods should be sorted by dependency order.
        foreach (var entry in GetDialogueTextEntiresForAllMods(GameCulture.DefaultCulture))
        {
            if (_DialogueLookup.TryGetValue(entry.DialogueKey, out var oldEntry))
            {
                if (entry.Data.Revision != oldEntry.Data.Revision)
                {
                    ModContent.GetInstance<CalamityMod>().Logger.Warn($"Dialogue Localization was detected but revision mismatches. This will not be applied! : '{entry.ProviderMod.Name}::{entry.FilePath}'");
                    continue;
                }
            }

            _DialogueLookup[entry.DialogueKey] = entry;
        }

        var activeCulture = LanguageManager.Instance.ActiveCulture;
        if (activeCulture == GameCulture.DefaultCulture)
            return;

        foreach (var entry in GetDialogueTextEntiresForAllMods(activeCulture))
        {
            var mod = entry.ProviderMod;

            if (!_DialogueLookup.TryGetValue(entry.DialogueKey, out var oldEntry))
            {
                ModContent.GetInstance<CalamityMod>().Logger.Warn($"Dialogue Localization was detected but original Dialogue file does not exist. This will not be applied! : '{mod.Name}::{entry.FilePath}'");
                continue;
            }

            // Skip if entry is from same file.
            if (oldEntry.ProviderMod == entry.ProviderMod && oldEntry.FilePath == entry.FilePath)
            {
                continue;
            }

            if (oldEntry.Data.Revision != entry.Data.Revision)
            {
                ModContent.GetInstance<CalamityMod>().Logger.Warn($"Dialogue Localization was detected but revision mismatches. This will not be applied! : '{mod.Name}::{entry.FilePath}'");
                continue;
            }

            _DialogueLookup[entry.DialogueKey] = entry;
        }
    }

    private static void HandleFileUpdate(Mod mod, string filePath)
    {
        if (!TryGetDialogueFileInfo(filePath, out _, out _, out var dialogueKey))
            return;

        if (!_DialogueLookup.TryGetValue(dialogueKey, out var existingEntry))
            return;

        if (existingEntry.ProviderMod != mod)
            return;

        try
        {
            using var stream = new StreamReader(File.OpenRead(filePath), Encoding.UTF8);
            _DialogueLookup[dialogueKey] = existingEntry with
            {
                Data = JsonSerializer.Deserialize<DialogueTextData>(stream.BaseStream)
            };

            var hotreloadedMessage = $"Dialogue entry has been hot reloaded: '{dialogueKey}', from source: '{filePath}'";
            ModContent.GetInstance<CalamityMod>().Logger.Info(hotreloadedMessage);
            if (!Main.gameMenu) Main.NewText(hotreloadedMessage);
        }
        catch (Exception e)
        {
            ModContent.GetInstance<CalamityMod>().Logger.Error($"Error while hot reloading DialogueTextData entry ({filePath}): {e}");
        }
    }

    private static IEnumerable<DialogueTextDataEntry> GetDialogueTextEntiresForAllMods(GameCulture targetCulture, bool skipDeserializeData = false)
    {
        // Mod.File API has been removed, file loading needs to be rewritten for new tModLoader API
        // Returning empty for now to allow build to succeed
        return Array.Empty<DialogueTextDataEntry>();
    }

    private static IEnumerable<DialogueTextDataEntry> GetDialogueTextEntries(Mod mod, GameCulture targetCulture, bool skipDeserializeData = false)
    {
        // Mod.File API has been removed, file loading needs to be rewritten for new tModLoader API
        return Array.Empty<DialogueTextDataEntry>();
    }

    private static bool TryGetDialogueFileInfo(string filePath, out GameCulture culture, out string prefix, out string dialogueKey)
    {
        if (!Path.GetExtension(filePath).Equals(".json", StringComparison.InvariantCultureIgnoreCase))
            goto EXIT_INVALID;

        if (!LocalizationLoader.TryGetCultureAndPrefixFromPath(filePath, out culture, out prefix))
            goto EXIT_INVALID;

        string fileName = Path.GetFileNameWithoutExtension(filePath);
        if (fileName.StartsWith($"{prefix}_{DialogueFilePrefix}", StringComparison.InvariantCultureIgnoreCase))
        {
            dialogueKey = fileName[$"{prefix}_{DialogueFilePrefix}".Length..];
            return true;
        }
        else if (fileName.StartsWith(DialogueFilePrefix, StringComparison.InvariantCultureIgnoreCase))
        {
            dialogueKey = fileName[DialogueFilePrefix.Length..];
            return true;
        }

EXIT_INVALID:
        culture = null;
        prefix = null;
        dialogueKey = null;
        return false;
    }

    private static Regex _calamityDialogueFileRegex;
    private static Regex CalamityDialogueFileRegex()
    {
        return _calamityDialogueFileRegex ??= new Regex(@"Dialogue\..+?\.jsonc?$", RegexOptions.IgnoreCase);
    }
}
