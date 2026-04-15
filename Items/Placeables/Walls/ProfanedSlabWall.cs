using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureProfaned;
using Terraria.ID;
using Terraria.ModLoader;
using WallTiles = CalamityModCustomPublicPrivateFork.Walls;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class ProfanedSlabWall : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<WallTiles.ProfanedSlabWall>());

        public override void AddRecipes()
        {
            CreateRecipe(4).
                AddIngredient<ProfanedSlab>().
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
