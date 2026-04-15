using CalamityModCustomPublicPrivateFork.Items.Placeables.Astral;
using Terraria.ID;
using Terraria.ModLoader;
using WallTiles = CalamityModCustomPublicPrivateFork.Walls;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class AstralDirtWall : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<WallTiles.AstralDirtWall>());

        public override void AddRecipes()
        {
            CreateRecipe(4).
                AddIngredient<AstralDirt>().
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
