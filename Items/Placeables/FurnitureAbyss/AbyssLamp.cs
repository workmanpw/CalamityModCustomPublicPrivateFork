using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAbyss
{
    public class AbyssLamp : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FurnitureAbyss.AbyssLamp>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SmoothAbyssGravel>(3).
                AddIngredient(ItemID.Torch).
                AddTile<VoidCondenser>().
                Register();
        }
    }
}
