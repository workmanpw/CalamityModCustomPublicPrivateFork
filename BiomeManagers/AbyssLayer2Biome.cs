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
    public class AbyssLayer2Biome : ModBiome
    {
        public override int Music
        {
            get
            {
                if (CalamityPlayer.areThereAnyDamnBosses)
                    return Main.curMusic;
                return ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AbyssLayer2") ?? MusicID.Hell;
            }
        }

        public override ModWaterStyle WaterStyle => UpperAbyssWater.Instance;
        public override int BiomeTorchItemType => ModContent.ItemType<KelpTorch>();
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/AbyssLayer2Icon";
        public override string BackgroundPath => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer23";
        public override string MapBackground => "CalamityModCustomPublicPrivateFork/Backgrounds/MapBackgrounds/AbyssBGLayer23";

        public override bool IsBiomeActive(Player player)
        {
            if (Main.remixWorld)
            {
                return AbyssLayer1Biome.MeetsBaseAbyssRequirement(player, out int playerYTileCoords) && BiomeTileCounterSystem.Layer2Tiles >= 200 &&
                playerYTileCoords <= SulphurousSea.YStart - (int)(Main.UnderworldLayer * 0.2f) && playerYTileCoords > SulphurousSea.YStart - (int)(Main.UnderworldLayer * 0.4f);
            }

            return AbyssLayer1Biome.MeetsBaseAbyssRequirement(player, out int playerYTileCoords2) && BiomeTileCounterSystem.Layer2Tiles >= 200 &&
            playerYTileCoords2 > Main.rockLayer - 10 && playerYTileCoords2 <= Main.rockLayer + Main.maxTilesY * 0.143;
        }
    }
}
