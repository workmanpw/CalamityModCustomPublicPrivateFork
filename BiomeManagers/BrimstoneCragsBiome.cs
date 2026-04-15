using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Systems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.BiomeManagers
{
    public class BrimstoneCragsBiome : ModBiome
    {
        public override int Music => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("BrimstoneCrags") ?? MusicID.Eerie;
        public override int BiomeTorchItemType => ModContent.ItemType<GloomTorch>();
        public override SceneEffectPriority Priority => SceneEffectPriority.Environment;
        public override string BestiaryIcon => "CalamityModCustomPublicPrivateFork/BiomeManagers/BrimstoneCragsIcon";
        public override string BackgroundPath => "Terraria/Images/MapBG3";

        public override bool IsBiomeActive(Player player)
        {
            return BiomeTileCounterSystem.BrimstoneCragTiles > 500 && player.ZoneUnderworldHeight;
        }
    }
}
