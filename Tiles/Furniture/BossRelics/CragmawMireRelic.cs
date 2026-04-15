using CalamityModCustomPublicPrivateFork.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossRelics
{
    public class CragmawMireRelic : BaseBossRelic
    {
        public override string RelicTextureName => "CalamityModCustomPublicPrivateFork/Tiles/Furniture/BossRelics/CragmawMireRelic";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Furniture.BossRelics.CragmawMireRelic>();
    }
}
