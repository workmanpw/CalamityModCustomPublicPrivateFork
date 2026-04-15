using CalamityModCustomPublicPrivateFork.Items.Placeables.Crags;
using Terraria.ID;
using Terraria.ModLoader;
using WallTiles = CalamityModCustomPublicPrivateFork.Walls;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class BrimstoneSlagWall : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<WallTiles.BrimstoneSlagWall>());

        public override void AddRecipes()
        {
            CreateRecipe(4).
                AddIngredient<BrimstoneSlag>().
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
