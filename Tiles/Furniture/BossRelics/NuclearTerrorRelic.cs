using CalamityModCustomPublicPrivateFork.Tiles.BaseTiles;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Furniture.BossRelics
{
    public class NuclearTerrorRelic : BaseBossRelic
    {
        public override string RelicTextureName => "CalamityModCustomPublicPrivateFork/Tiles/Furniture/BossRelics/NuclearTerrorRelic";

        public override int AssociatedItem => ModContent.ItemType<Items.Placeables.Furniture.BossRelics.NuclearTerrorRelic>();
    }
}
