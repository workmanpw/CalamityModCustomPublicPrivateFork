using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Ambient.SunkenSea
{
    public class BranchCoralEcho : BranchCoral
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/BranchCoral";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Limestone>(), Type, 0);
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<Limestone>(), Type, 0);
        }
    }
}
