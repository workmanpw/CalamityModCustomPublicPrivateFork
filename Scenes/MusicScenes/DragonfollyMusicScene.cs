using CalamityModCustomPublicPrivateFork.NPCs.Bumblebirb;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class DragonfollyMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<Dragonfolly>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("Dragonfolly");
        public override int VanillaMusic => MusicID.Boss4;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
    }
}
