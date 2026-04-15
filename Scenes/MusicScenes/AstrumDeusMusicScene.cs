using CalamityModCustomPublicPrivateFork.NPCs.AstrumDeus;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class AstrumDeusMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<AstrumDeusHead>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AstrumDeus");
        public override int VanillaMusic => MusicID.Boss3;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
        public override int[] AdditionalNPCs => new int[]
        {
            ModContent.NPCType<AstrumDeusBody>(),
            ModContent.NPCType<AstrumDeusTail>()
        };
    }
}
