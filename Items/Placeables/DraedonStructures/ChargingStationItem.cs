using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.DraedonStructures;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.DraedonStructures
{
    public class ChargingStationItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ChargingStation>());
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ModContent.RarityType<DarkOrange>();
        }
    }
}
