using Terraria.ModLoader;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using Terraria.GameContent;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class GiantNavystone1Echo : GiantNavystone1
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/GiantNavystone1";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Navystone>(), Type, 0);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Navystone>(), Type, 0);
        }
    }

    public class GiantNavystone2Echo : GiantNavystone2
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/GiantNavystone2";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Navystone>(), Type, 0);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Navystone>(), Type, 0);
        }
    }
}
