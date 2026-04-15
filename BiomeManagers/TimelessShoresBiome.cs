using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Waters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class TimelessShoresBiome : ModBiome
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

        public override bool IsBiomeActive(Player player)
        {
            bool MoreThanReefs = BiomeTileCounterSystem.SunkenSeaShoresTiles > BiomeTileCounterSystem.SunkenSeaReefsTiles;
            bool MoreThanBasalt = BiomeTileCounterSystem.SunkenSeaShoresTiles > BiomeTileCounterSystem.SunkenSeaBasaltTiles;
            bool MoreThanUnderground = BiomeTileCounterSystem.SunkenSeaShoresTiles > BiomeTileCounterSystem.UndergroundTiles;

            return (BiomeTileCounterSystem.SunkenSeaShoresTiles > 1200) && MoreThanReefs && MoreThanBasalt && MoreThanUnderground;
        }
    }
}
