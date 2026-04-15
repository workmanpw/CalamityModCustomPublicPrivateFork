using CalamityModCustomPublicPrivateFork.NPCs.Signus;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class SignusMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<Signus>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("Signus");
        public override int VanillaMusic => MusicID.Boss4;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
    }
}
