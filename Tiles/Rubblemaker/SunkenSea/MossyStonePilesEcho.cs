using Terraria.ModLoader;
using Terraria.GameContent;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class SmallMossyStonePileEcho : SmallMossyStonePile
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/SmallMossyStonePile";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<MossyStone>());
            FlexibleTileWand.RubblePlacementSmall.AddVariations(ModContent.ItemType<MossyStone>(), Type, 0, 1, 2, 3, 4, 5);
        }
    }
    public class LargeMossyStonePileEcho : LargeMossyStonePile
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/LargeMossyStonePile";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<MossyStone>());
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<MossyStone>(), Type, 0, 1, 2);
        }
    }
}
