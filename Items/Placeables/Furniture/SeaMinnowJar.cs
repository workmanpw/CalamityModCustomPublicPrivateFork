using CalamityModCustomPublicPrivateFork.Items.Critters;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture
{
    public class SeaMinnowJar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SeaMinnowJarTile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SeaMinnowItem>().
                AddIngredient(ItemID.BottledWater).
                Register();
        }
    }
}
