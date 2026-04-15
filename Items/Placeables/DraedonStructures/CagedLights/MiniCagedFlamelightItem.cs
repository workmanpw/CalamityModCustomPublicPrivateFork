using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Plates;
using CalamityModCustomPublicPrivateFork.Tiles.DraedonStructures.CagedLights;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.DraedonStructures.CagedLights
{
    public class MiniCagedFlamelightItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<MiniAgedFlamelightItem>();

            Item.DefaultToPlaceableTile(ModContent.TileType<MiniCagedFlamelight>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe(20).
                AddIngredient<DubiousPlating>().
                AddIngredient<MysteriousCircuitry>(2).
                AddIngredient<Havocplate>().
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
