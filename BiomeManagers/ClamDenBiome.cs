using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Waters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class ClamDenBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => SunkenSeaBurrowsWater.Instance;
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("CalamityModCustomPublicPrivateFork/SunkenSeaBGStyle");
        public override int BiomeTorchItemType => ModContent.ItemType<NavyPrismTorch>();
        public override int Music => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("SunkenSea") ?? MusicID.OceanNight;
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/SunkenSeaIcon";
        // Placeholder until we get a dedicated Sunken Sea background
        public override string BackgroundPath => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer1";
        public override string MapBackground => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer1";

        // todo make this condition different than the normal burrows
        public override bool IsBiomeActive(Player player)
        {
            bool MoreThanReefs = BiomeTileCounterSystem.SunkenSeaBurrowsTiles > BiomeTileCounterSystem.SunkenSeaReefsTiles;
            bool MoreThanPolyp = BiomeTileCounterSystem.SunkenSeaBurrowsTiles > BiomeTileCounterSystem.SunkenSeaPolypTiles;

            return BiomeTileCounterSystem.SunkenSeaBurrowsTiles > 1000 && MoreThanReefs && MoreThanPolyp;
        }
    }
}
