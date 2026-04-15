using CalamityModCustomPublicPrivateFork.NPCs.BrimstoneElemental;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class BrimstoneElementalMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<BrimstoneElemental>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("BrimstoneElemental");
        public override int VanillaMusic => MusicID.Boss4;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
    }
}
