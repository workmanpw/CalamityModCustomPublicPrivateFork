using Terraria.ModLoader;
using WallTiles = CalamityModCustomPublicPrivateFork.Walls;
using Terraria.ID;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class LimestoneWall : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<WallTiles.LimestoneWall>());

        public override void AddRecipes()
        {
            CreateRecipe(4).
                AddIngredient<Limestone>().
                AddTile(TileID.WorkBenches).
                Register();
        }

    }
}
