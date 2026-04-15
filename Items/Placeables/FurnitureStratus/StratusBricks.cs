using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Ores;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Walls;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureStratus
{
    public class StratusBricks : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureStratus.StratusBricks>());

        public override void AddRecipes()
        {
            CreateRecipe(200).
                AddRecipeGroup("AnyStoneBlock", 200).
                AddIngredient<Lumenyl>(3).
                AddIngredient<RuinousSoul>().
                AddIngredient<ExodiumCluster>().
                AddTile<Tiles.Furniture.CraftingStations.VoidCondenser>().
                Register();
            CreateRecipe().
                AddIngredient<StratusWall>(4).
                AddTile(TileID.WorkBenches).
                DisableDecraft().
                Register();
            CreateRecipe().
                AddIngredient<StratusPlatform>(2).
                DisableDecraft().
                Register();
            CreateRecipe().
                AddIngredient<StratusStarPlatformItem>(2).
                DisableDecraft().
                Register();
        }
    }
}
