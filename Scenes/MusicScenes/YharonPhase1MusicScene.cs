using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.Yharon;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class YharonPhase1MusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<Yharon>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("YharonPhase1");
        public override int VanillaMusic => MusicID.Boss3;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;

        public override bool AdditionalCheck() => CalamityGlobalNPC.yharon != -1 && CalamityGlobalNPC.yharonP2 == -1;
    }
}
