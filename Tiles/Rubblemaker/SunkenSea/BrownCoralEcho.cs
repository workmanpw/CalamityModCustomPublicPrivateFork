using Terraria.ModLoader;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using Terraria.GameContent;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class BrownCoral1Echo : BrownCoral1
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/BrownCoral1";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<YellowCoral>());
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<YellowCoral>(), Type, 0);
        }
    }

    public class BrownCoral2Echo : BrownCoral2
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/BrownCoral2";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<YellowCoral>());
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<YellowCoral>(), Type, 0);
        }
    }
}
