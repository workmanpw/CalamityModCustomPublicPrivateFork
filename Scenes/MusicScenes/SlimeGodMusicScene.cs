using CalamityModCustomPublicPrivateFork.NPCs.SlimeGod;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class SlimeGodMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<SlimeGodCore>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("SlimeGod");
        public override int VanillaMusic => MusicID.Boss1;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss1;
    }
}
