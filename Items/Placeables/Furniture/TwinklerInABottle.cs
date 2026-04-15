using CalamityModCustomPublicPrivateFork.Items.Critters;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture
{
    public class TwinklerInABottle : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<TwinklerInABottleTile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.Bottle).
                AddIngredient<TwinklerItem>().
                Register();
        }
    }
}
