using CalamityModCustomPublicPrivateFork.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossRelics
{
    public class RavagerRelic : BaseBossRelic
    {
        public override string RelicTextureName => "CalamityModCustomPublicPrivateFork/Tiles/Furniture/BossRelics/RavagerRelic";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Furniture.BossRelics.RavagerRelic>();
    }
}
