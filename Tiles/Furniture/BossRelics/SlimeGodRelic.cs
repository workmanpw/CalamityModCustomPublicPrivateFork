using CalamityModCustomPublicPrivateFork.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossRelics
{
    public class SlimeGodRelic : BaseBossRelic
    {
        public override string RelicTextureName => "CalamityModCustomPublicPrivateFork/Tiles/Furniture/BossRelics/SlimeGodRelic";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Furniture.BossRelics.SlimeGodRelic>();
    }
}
