using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class WallCoralEcho : WallCoral
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/WallCoral";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Shellstone>(), Type);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Shellstone>(), Type, 0, 1, 2, 3);
        }
    }

    public class WallCoralLeftEcho : WallCoralLeft
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/WallCoralLeft";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Shellstone>(), Type);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Shellstone>(), Type, 0, 1, 2, 3);
        }
    }
}
