using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Waters;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class AstralInfectionBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => AstralWater.Instance;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
        {
            get
            {
                if (Main.LocalPlayer.ZoneSnow) //Snow
                {
                    return ModContent.Find<ModSurfaceBackgroundStyle>("CalamityModCustomPublicPrivateFork/AstralSnowSurfaceBGStyle");
                }
                else if (Main.LocalPlayer.ZoneDesert && !Main.LocalPlayer.ZoneSnow) //Desert
                {
                    return ModContent.Find<ModSurfaceBackgroundStyle>("CalamityModCustomPublicPrivateFork/AstralDesertSurfaceBGStyle");
                }
                else //surface
                {
                    return ModContent.Find<ModSurfaceBackgroundStyle>("CalamityModCustomPublicPrivateFork/AstralSurfaceBGStyle");
                }
            }
        }

        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle
        {
            get
            {
                if (Main.LocalPlayer.ZoneSnow)
                {
                    return ModContent.Find<ModUndergroundBackgroundStyle>("CalamityModCustomPublicPrivateFork/AstralUndergroundBGStyle"); // Could use its own unique background
                }
                return ModContent.Find<ModUndergroundBackgroundStyle>("CalamityModCustomPublicPrivateFork/AstralUndergroundBGStyle");
            }
        }

        public override int BiomeTorchItemType => ModContent.ItemType<AstralTorch>();

        public override SceneEffectPriority Priority
        {
            get
            {
                if (Main.LocalPlayer.ZoneDesert && Sandstorm.Happening && !(Main.LocalPlayer.ZoneSnow || Main.slimeRain || Main.eclipse))
                {
                    return SceneEffectPriority.Environment;
                }
                else
                {
                    return SceneEffectPriority.BiomeHigh;
                }
            }
        }

        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/AbovegroundAstralBiomeIcon";

        public override string BackgroundPath 
        { 
            get
            {
                if (Main.LocalPlayer.ZoneDesert && !Main.LocalPlayer.ZoneSnow)
                {
                    //desert
                    return "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AstralBG"; // Could use its own unique background
                }
                else if (Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneUnderworldHeight)
                {
                    //underground
                    return "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AstralBG"; // Could use its own unique background
                }
                else
                {
                    return "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AstralBG";
                }
            } 
        }
        public override string MapBackground => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AstralBG";

        public override int Music
        {
            get
            {
                if (Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneUnderworldHeight)
                {
                    return ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AstralInfectionUnderground") ?? MusicID.Space;
                }
                return ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AstralInfection") ?? MusicID.Space;
            }
        }

        public override bool IsBiomeActive(Player player)
        {
            return !player.ZoneDungeon && BiomeTileCounterSystem.AstralTiles > 950;
        }

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("CalamityMod:Astral", isActive);
            if (Main.LocalPlayer.ZoneDirtLayerHeight || Main.LocalPlayer.ZoneRockLayerHeight || Main.LocalPlayer.ZoneUnderworldHeight)
            {
                player.ManageSpecialBiomeVisuals("CalamityMod:Astral", isActive); //underground
            }
        }
    }
}
