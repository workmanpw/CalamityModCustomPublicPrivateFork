using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.Yharon;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class YharonPhase2MusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<Yharon>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("YharonPhase2");
        public override int VanillaMusic => MusicID.LunarBoss;
        public override int OtherworldMusic => MusicID.OtherworldlyLunarBoss;

        public override bool AdditionalCheck() => CalamityGlobalNPC.yharonP2 != -1;
    }
}
