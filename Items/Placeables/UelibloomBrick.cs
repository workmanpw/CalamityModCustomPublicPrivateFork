using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureBotanic;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Ores;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Walls;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables
{
    public class UelibloomBrick : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.UelibloomBrick>());

        public override void AddRecipes()
        {
            CreateRecipe(50).
                AddRecipeGroup("AnyStoneBlock", 50).
                AddIngredient<UelibloomOre>().
                AddTile(TileID.AdamantiteForge).
                Register();
            CreateRecipe().
                AddIngredient<UelibloomBrickWall>(4).
                AddTile(TileID.WorkBenches).
                DisableDecraft().
                Register();
            CreateRecipe().
                AddIngredient<BotanicPlatform>(2).
                DisableDecraft().
                Register();
        }
    }
}
