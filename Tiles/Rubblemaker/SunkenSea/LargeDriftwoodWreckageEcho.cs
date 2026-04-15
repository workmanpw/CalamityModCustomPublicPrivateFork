using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureDriftwood;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class LargeDriftwoodWreckageEcho : LargeDriftwoodWreckage
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/LargeDriftwoodWreckage";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<Driftwood>(), Type);
            FlexibleTileWand.RubblePlacementLarge.AddVariations(ModContent.ItemType<Driftwood>(), Type, 0, 1, 2, 3, 4, 5);
        }
    }
}
