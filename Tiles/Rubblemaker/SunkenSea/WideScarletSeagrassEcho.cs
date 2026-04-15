using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class WideScarletSeagrassEcho : WideScarletSeagrass
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/WideScarletSeagrass";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<PolypSand>(), Type);
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<PolypSand>(), Type, 0, 1, 2, 3);
        }
    }
}
