using CalamityModCustomPublicPrivateFork.NPCs.Leviathan;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class AnahitasLureMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override int NPCType => ModContent.NPCType<LeviathanStart>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("AnahitasLure");
        public override int VanillaMusic => -1;
        public override int OtherworldMusic => -1;
        public override int MusicDistance => 1600;
    }
}
