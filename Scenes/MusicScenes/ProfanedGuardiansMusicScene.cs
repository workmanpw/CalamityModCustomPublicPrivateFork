using CalamityMod.NPCs.ProfanedGuardians;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityMod.Systems
{
    public class ProfanedGuardiansMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<ProfanedGuardianCommander>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("ProfanedGuardians");
        public override int VanillaMusic => MusicID.Boss1;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss1;
    }
}
