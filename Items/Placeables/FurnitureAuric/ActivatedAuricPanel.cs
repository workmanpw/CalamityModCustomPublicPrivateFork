using CalamityModCustomPublicPrivateFork.Items.Placeables.Ores;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAuric;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAuric
{
    public class ActivatedAuricPanel : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }
        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<ActivatedAuricPanelTile>());

        public override void AddRecipes()
        {
            CreateRecipe(400).
                AddRecipeGroup("AnyStoneBlock", 400).
                AddIngredient<AuricOre>().
                AddTile<CosmicAnvil>().
                Register();
            /*CreateRecipe().
                AddIngredient<ActivatedAuricPanelWallItem>(4).
                AddTile(TileID.WorkBenches).
                DisableDecraft().
                Register();*/
        }
    }
}
