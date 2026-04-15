using Terraria.ModLoader;
using WallTiles = CalamityModCustomPublicPrivateFork.Walls;
using Terraria.ID;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureShellstone;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class ShellTrimBrickWall : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<WallTiles.ShellTrimBrickWall>());

        public override void AddRecipes() 
        {
            CreateRecipe(4).
                AddIngredient<ShellTrimBrick>().
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
