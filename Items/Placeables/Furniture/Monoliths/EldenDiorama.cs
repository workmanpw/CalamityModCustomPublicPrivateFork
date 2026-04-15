using CalamityModCustomPublicPrivateFork.ForegroundDrawing.LoopingTextures;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.Monoliths;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Monoliths
{
    [LegacyName("OldDukeMonolith")]
    public class EldenDiorama : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<OldDukeMonolithTile>());
            Item.value = Item.sellPrice(gold: 20);
            Item.rare = ModContent.RarityType<PureGreen>();
            Item.accessory = true;
            Item.vanity = true;
        }

        public override void UpdateEquip(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.GetModPlayer<NuclearTorrentPlayer>().ShouldDisplayTorrentMonolith = true;
            }
        }
        public override void UpdateVanity(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.GetModPlayer<NuclearTorrentPlayer>().ShouldDisplayTorrentMonolith = true;
            }
        }
    }
}
