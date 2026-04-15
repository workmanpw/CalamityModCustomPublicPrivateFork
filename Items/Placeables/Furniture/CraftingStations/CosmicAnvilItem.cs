using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Ores;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.CraftingStations
{
    public class CosmicAnvilItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<CosmicAnvil>());
            Item.value = Item.sellPrice(gold: 50);
            Item.rare = ModContent.RarityType<CosmicPurple>();
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddRecipeGroup("HardmodeAnvil").
                AddIngredient<CosmiliteBar>(10).
                AddIngredient(ItemID.LunarBar, 10).
                AddIngredient<GalacticaSingularity>(12).
                AddIngredient<ExodiumCluster>(20).
                AddTile(TileID.LunarCraftingStation).
                Register();
        }
    }
}
