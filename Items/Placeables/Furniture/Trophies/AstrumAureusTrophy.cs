using CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossTrophies;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Trophies
{
    [LegacyName("AstrageldonTrophy")]
    public class AstrumAureusTrophy : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AstrumAureusTrophyTile>());
            Item.width = Item.height = 30;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
        }
    }
}
