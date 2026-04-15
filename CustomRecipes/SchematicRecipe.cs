using System;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.CustomRecipes
{
    public static class SchematicRecipe
    {
        // TODO -- Use an enumeration instead of strings in the switch cases.
        public static LocalizedText ConstructRecipeCondition(string schematicName, out Func<bool> condition)
        {
            switch (schematicName)
            {
                case "Sunken Sea":
                default:
                    condition = new Func<bool>(() => RecipeUnlockHandler.HasFoundSunkenSeaSchematic);
                    return Language.GetOrRegister($"Mods.CalamityModCustomPublicPrivateFork.Misc.SunkenSeaSchematicRecipeCondition");
                case "Planetoid":
                    condition = new Func<bool>(() => RecipeUnlockHandler.HasFoundPlanetoidSchematic);
                    return Language.GetOrRegister($"Mods.CalamityModCustomPublicPrivateFork.Misc.PlanetoidSchematicRecipeCondition");
                case "Jungle":
                    condition = new Func<bool>(() => RecipeUnlockHandler.HasFoundJungleSchematic);
                    return Language.GetOrRegister($"Mods.CalamityModCustomPublicPrivateFork.Misc.JungleSchematicRecipeCondition");
                case "Hell":
                    condition = new Func<bool>(() => RecipeUnlockHandler.HasFoundHellSchematic);
                    return Language.GetOrRegister($"Mods.CalamityModCustomPublicPrivateFork.Misc.UnderworldSchematicRecipeCondition");
                case "Ice":
                    condition = new Func<bool>(() => RecipeUnlockHandler.HasFoundIceSchematic);
                    return Language.GetOrRegister($"Mods.CalamityModCustomPublicPrivateFork.Misc.IceSchematicRecipeCondition");
            }
        }
    }
}
