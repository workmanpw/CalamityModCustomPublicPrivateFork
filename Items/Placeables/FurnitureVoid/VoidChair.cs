using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureVoid
{
    public class VoidChair : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureVoid.VoidChair>());
            Item.value = Item.sellPrice(copper: 30);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SmoothVoidstone>(4).
                AddTile<VoidCondenser>().
                Register();
        }
    }
}
