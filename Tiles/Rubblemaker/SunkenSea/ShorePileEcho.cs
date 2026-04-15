using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class ShorePileEcho : ShorePile
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/ShorePile";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Runestone>(), Type);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Runestone>(), Type, 0, 1, 2, 3, 4, 5, 6, 7, 8);
        }
    }
}
