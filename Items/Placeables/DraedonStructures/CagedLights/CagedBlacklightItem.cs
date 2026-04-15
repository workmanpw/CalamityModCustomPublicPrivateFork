using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Plates;
using CalamityModCustomPublicPrivateFork.Tiles.DraedonStructures.CagedLights;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.DraedonStructures.CagedLights
{
    public class CagedBlacklightItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<AgedBlacklightItem>();

            Item.DefaultToPlaceableTile(ModContent.TileType<CagedBlacklight>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe(10).
                AddIngredient<DubiousPlating>(2).
                AddIngredient<MysteriousCircuitry>().
                AddIngredient<Onyxplate>().
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
