using CalamityModCustomPublicPrivateFork.Items.Placeables.Walls;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureShellstone
{
    public class ShellstoneSlab : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureShellstone.ShellstoneSlab>());

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Shellstone>().
                AddTile(TileID.HeavyWorkBench).
                Register();
            CreateRecipe().
                AddIngredient<ShellstoneSlabWall>(4).
                AddTile(TileID.WorkBenches).
                DisableDecraft().
                Register();
        }
    }
}
