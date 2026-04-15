using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Tiles.DraedonStructures.CagedLights;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.DraedonStructures.CagedLights
{
    public class CagedLablightItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<AgedLablightItem>();

            Item.DefaultToPlaceableTile(ModContent.TileType<CagedLablight>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe(10).
                AddIngredient<DubiousPlating>(2).
                AddIngredient<MysteriousCircuitry>().
                AddIngredient<DraedonPowerCell>().
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
