using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.SupremeCalamitas;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class CalamitasDefeatMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<SupremeCalamitas>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("CalamitasDefeat");
        public override int VanillaMusic => MusicID.Eerie;
        public override int OtherworldMusic => MusicID.OtherworldlyEerie;

        public override bool AdditionalCheck() => CalamityGlobalNPC.SCalAcceptance != -1;
    }
}
