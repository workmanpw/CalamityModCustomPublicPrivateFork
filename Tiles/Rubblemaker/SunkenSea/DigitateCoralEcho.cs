using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using CalamityModCustomPublicPrivateFork.Tiles.SunkenSea.Ambient;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles.Rubblemaker.SunkenSea
{
    public class DigitateCoralEcho : DigitateCoral
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Tiles/SunkenSea/Ambient/DigitateCoral";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            RegisterItemDrop(ModContent.ItemType<LimeCoral>());
            FlexibleTileWand.RubblePlacementMedium.AddVariations(ModContent.ItemType<LimeCoral>(), Type, 0);
        }
    }
}
