using CalamityModCustomPublicPrivateFork.Items.Placeables.Walls;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAshen
{
    public class AshenSlab : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureAshen.AshenSlab>());

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SmoothBrimstoneSlag>().
                AddTile<AshenAltar>().
                Register();
            CreateRecipe().
                AddIngredient<AshenSlabWall>(4).
                AddTile(TileID.WorkBenches).
                DisableDecraft().
                Register();
        }
    }
}
