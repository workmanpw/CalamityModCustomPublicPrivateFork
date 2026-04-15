using CalamityModCustomPublicPrivateFork.Tiles.Pylons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Pylons
{
    public class SunkenPylon : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SunkenPylonTile>());

            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Blue;
        }
    }
}
