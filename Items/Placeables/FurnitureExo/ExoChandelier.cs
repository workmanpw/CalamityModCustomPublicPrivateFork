using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureExo;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureExo
{
    public class ExoChandelier : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ExoChandelierTile>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<ExoPlating>(4).
                AddIngredient(ItemID.Torch, 4).
                AddIngredient(ItemID.Chain).
                AddTile<DraedonsForge>().
                Register();
        }
    }
}
