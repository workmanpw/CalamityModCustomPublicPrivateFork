using CalamityModCustomPublicPrivateFork.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossRelics
{
    public class OldDukeRelic : BaseBossRelic
    {
        public override string RelicTextureName => "CalamityModCustomPublicPrivateFork/Tiles/Furniture/BossRelics/OldDukeRelic";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Furniture.BossRelics.OldDukeRelic>();
    }
}
