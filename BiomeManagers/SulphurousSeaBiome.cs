using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Events;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Waters;
using CalamityModCustomPublicPrivateFork.World;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class SulphurousSeaBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => Main.zenithWorld ? PissWater.Instance : SulphuricWater.Instance;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => Main.zenithWorld ? ModContent.Find<ModSurfaceBackgroundStyle>("CalamityModCustomPublicPrivateFork/PissSeaSurfaceBGStyle") : ModContent.Find<ModSurfaceBackgroundStyle>("CalamityModCustomPublicPrivateFork/SulphurSeaSurfaceBGStyle");
        public override int BiomeTorchItemType => ModContent.ItemType<SulphurousTorch>();
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/SulphurousSeaIcon";
        public override string BackgroundPath => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/SulphurBG";
        public override string MapBackground => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/SulphurBG";

        public override int Music
        {
            get
            {
                int music = Main.curMusic;
                if (!CalamityPlayer.areThereAnyDamnBosses)
                {
                    bool acidRain = AcidRainEvent.AcidRainEventIsOngoing;
                    bool normalRain = Main.cloudAlpha > 0f;

                    // Acid Rain themes
                    if (acidRain)
                    {
                        music = DownedBossSystem.downedPolterghast
                        ? ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AcidRainTier3") ?? MusicID.Monsoon // Acid Rain Tier 3
                        : ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AcidRainTier1") ?? MusicID.OldOnesArmy; // Acid Rain Tier 1 + 2
                    }

                    // Regular Sulphur Sea themes, when Acid Rain is not occurring
                    else
                    {
                        if (normalRain)
                        {
                            music = ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("SulphurousSeaRain") ?? MusicID.Desert; // Normal Rain
                        }
                        else
                        {
                            music = !Main.dayTime
                            ? ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("SulphurousSeaNight") ?? MusicID.Desert // Nighttime
                            : ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("SulphurousSeaDay") ?? MusicID.Desert; // Daytime
                        }
                    }
                }

                return music;
            }
        }

        public override bool IsBiomeActive(Player player)
        {
            Point point = player.Center.ToTileCoordinates();
            return BiomeTileCounterSystem.SulphurTiles >= 300 || IsInBiomePosition(point) && !player.Calamity().ZoneAbyss;
        }

        public static bool IsInBiomePosition(Point tilePos)
        {
            bool sulphurPosX = false;

            if (Abyss.AtLeftSideOfWorld)
            {
                if (tilePos.X < 435)
                {
                    sulphurPosX = true;
                }
            }
            else
            {
                if (tilePos.X > Main.maxTilesX - 435)
                {
                    sulphurPosX = true;
                }
            }

            if (Main.remixWorld)
                return tilePos.Y > SulphurousSea.YStart && tilePos.Y < Main.UnderworldLayer && sulphurPosX && !WeakReferenceSupport.InAnySubworld();

            return tilePos.Y < (Main.rockLayer - Main.maxTilesY / 13) && sulphurPosX && !WeakReferenceSupport.InAnySubworld();
        }

        public override void SpecialVisuals(Player player, bool isActive)
        {
            string biomeName = "CalamityMod:SulphurSea";
            if (SkyManager.Instance[biomeName] != null && isActive != SkyManager.Instance[biomeName].IsActive())
            {
                if (isActive)
                {
                    SkyManager.Instance.Activate(biomeName);
                }
                else
                {
                    SkyManager.Instance.Deactivate(biomeName);
                }
            }
        }
    }
}
