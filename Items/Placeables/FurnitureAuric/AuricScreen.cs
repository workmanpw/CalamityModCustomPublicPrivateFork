using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAuric;
using Terraria;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAuric
{
    public class AuricScreen : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AuricScreenTile>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AuricPanel>(10).
                AddIngredient<DraedonPowerCell>(3).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
