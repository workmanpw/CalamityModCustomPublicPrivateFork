using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class TableCoralEcho : TableCoral
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/TableCoral";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Shellstone>());
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<Shellstone>(), Type, 0, 1, 2);
        }
    }
    public class TableCoralLeftEcho : TableCoralLeft
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/TableCoralLeft";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Shellstone>());
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<Shellstone>(), Type, 0, 1, 2);
        }
    }
}
