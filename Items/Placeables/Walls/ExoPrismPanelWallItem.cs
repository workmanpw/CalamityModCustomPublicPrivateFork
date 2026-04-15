using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureExo;
using CalamityModCustomPublicPrivateFork.Walls;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Walls
{
    public class ExoPrismPanelWallItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableWall(ModContent.WallType<ExoPrismPanelWall>());

        public override void AddRecipes()
        {
            CreateRecipe(4).
                AddIngredient<ExoPrismPanel>().
                AddTile(TileID.WorkBenches).
                Register();
        }
    }
}
