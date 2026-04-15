using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using CalamityModCustomPublicPrivateFork.Waters;
using CalamityModCustomPublicPrivateFork.World;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class AbyssLayer4Biome : ModBiome
    {
        public override int Music
        {
            get
            {
                if (CalamityPlayer.areThereAnyDamnBosses)
                    return Main.curMusic;
                return ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AbyssLayer4") ?? MusicID.Hell;
            }
        }

        public override ModWaterStyle WaterStyle => VoidWater.Instance;
        public override int BiomeTorchItemType => ModContent.ItemType<VoidTorch>();
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/AbyssLayer4Icon";
        public override string BackgroundPath => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer4";
        public override string MapBackground => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer4";

        public override bool IsBiomeActive(Player player)
        {
            if (Main.remixWorld)
            {
                return AbyssLayer1Biome.MeetsBaseAbyssRequirement(player, out int playerYTileCoords) && BiomeTileCounterSystem.Layer4Tiles >= 200 &&
                playerYTileCoords <= SulphurousSea.YStart - (int)(Main.UnderworldLayer * 0.6f);
            }

            return AbyssLayer1Biome.MeetsBaseAbyssRequirement(player, out int playerYTileCoords2) && BiomeTileCounterSystem.Layer4Tiles >= 200 &&
            playerYTileCoords2 > Main.rockLayer + Main.maxTilesY * 0.268;
        }
    }
}
