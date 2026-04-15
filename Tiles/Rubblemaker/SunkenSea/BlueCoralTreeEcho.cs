using Terraria.ModLoader;
using Terraria.GameContent;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class BlueCoralTreeEcho : BlueCoralTree
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/BlueCoralTree";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<CyanCoral>());
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<CyanCoral>(), Type, 0);
        }
    }
}
