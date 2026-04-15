using CalamityModCustomPublicPrivateFork.Items.Placeables.Crags;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAncient
{
    public class AncientSink : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureAncient.AncientSink>());
            Item.value = Item.sellPrice(copper: 60);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<BrimstoneSlag>(6).
                AddIngredient(ItemID.LavaBucket).
                AddTile<AshenAltar>().
                Register();
        }
    }
}
