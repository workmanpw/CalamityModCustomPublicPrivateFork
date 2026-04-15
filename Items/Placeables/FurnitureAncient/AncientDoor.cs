using CalamityModCustomPublicPrivateFork.Items.Placeables.Crags;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAncient;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAncient
{
    public class AncientDoor : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AncientDoorClosed>());
            Item.value = Item.sellPrice(copper: 40);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<BrimstoneSlag>(6).
                AddTile<AshenAltar>().
                Register();
        }
    }
}
