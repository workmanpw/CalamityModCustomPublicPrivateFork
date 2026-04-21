using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using ReLogic.OS;

namespace CalamityMod.UI
{
    public class WindowTitles : ModSystem
    {
        private static LocalizedText _calamityModifiedText;
        private static bool loaded = false; 
        public override void PostSetupContent()
        {
            if (Main.dedServ)
                return;

            Main.QueueMainThreadAction(() =>
            {
                // the other method involving some terraria intrinsic function didn't work, so i'm just ignoring it
                List<LocalizedText> vanillaTitles = new();
                List<LocalizedText> customTitles = new();

                // Retry mechanism for Language.FindAll to handle collection modification during mod loading
                for (int retry = 0; retry < 5; retry++)
                {
                    try
                    {
                        if (vanillaTitles.Count == 0)
                            vanillaTitles = Language.FindAll(new Regex("^GameTitle\\.")).ToList();
                        
                        if (customTitles.Count == 0)
                            customTitles = Language.FindAll(new Regex("^Mods\\.CalamityMod\\.UI\\.WindowTitle\\.")).ToList();
                        
                        // If both succeeded, break out of retry loop
                        if (vanillaTitles.Count > 0 || customTitles.Count > 0)
                            break;
                    }
                    catch (InvalidOperationException)
                    {
                        // Collection may be modified during enumeration, wait and retry
                        if (retry < 4)
                            System.Threading.Thread.Sleep(50);
                    }
                }

                var allTitles = new List<LocalizedText>();
                allTitles.AddRange(vanillaTitles);
                allTitles.AddRange(customTitles);

                if (allTitles.Count > 0)
                {
                    _calamityModifiedText ??= allTitles[Main.rand.Next(allTitles.Count)];

                    // this is what vanilla terraria does to set it's title, so i'm replicating that here
                    Platform.Get<IWindowService>().SetUnicodeTitle(Main.instance.Window, _calamityModifiedText.Value);
                    Platform.Get<IWindowService>().SetIcon(Main.instance.Window);
                }

                loaded = true;
            });
        }

        public override void Unload()
        {
            if (Main.dedServ)
                return;
            Main.QueueMainThreadAction(() =>
            {
            Platform.Get<IWindowService>().SetUnicodeTitle(Main.instance.Window, Lang.GetRandomGameTitle());
            Platform.Get<IWindowService>().SetIcon(Main.instance.Window);

            _calamityModifiedText = null;
            loaded = false;
            });
            base.Unload();
        }
    }
}
