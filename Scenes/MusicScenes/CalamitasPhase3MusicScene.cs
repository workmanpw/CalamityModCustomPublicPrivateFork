using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.SupremeCalamitas;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class CalamitasPhase3MusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<SupremeCalamitas>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("CalamitasPhase3");
        public override int VanillaMusic => MusicID.LunarBoss;
        public override int OtherworldMusic => MusicID.OtherworldlyLunarBoss;

        public override bool AdditionalCheck() => CalamityGlobalNPC.SCalEpiphany != -1;
    }
}
