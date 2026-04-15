using CalamityModCustomPublicPrivateFork.Items.Critters;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture
{
    public class BabyGhostBellJar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BabyGhostBellJarTile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<BabyGhostBellItem>().
                AddIngredient(ItemID.BottledWater).
                Register();
        }
    }
}
