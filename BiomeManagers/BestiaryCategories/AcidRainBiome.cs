//using CalamityModCustomPublicPrivateFork.Systems;

using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class AcidRainBiome : ModBiome
    {
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/AcidRainIcon";
        public override string BackgroundPath => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/SulphurBG"; //Probably needs a unique bg
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow; //Sulphurous Sea overrides it

        //Does this even need proper detection, the detection code is done elsewhere
        /*public override bool IsBiomeActive(Player player)
        {
            return AcidRainEvent.AcidRainEventIsOngoing && !DownedBossSystem.downedAquaticScourge && !DownedBossSystem.downedPolterghast;
        }*/
    }
}
