using CalamityModCustomPublicPrivateFork.Tiles.FurnitureStratus;
using Terraria;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureStratus
{
    public class StratusDoor : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<StratusDoorClosed>());
            Item.value = Item.sellPrice(copper: 40);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<StratusBricks>(6).
                AddTile<Tiles.Furniture.CraftingStations.VoidCondenser>().
                Register();
        }
    }
}
