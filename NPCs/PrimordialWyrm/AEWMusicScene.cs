using CalamityModCustomPublicPrivateFork.NPCs.PrimordialWyrm;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class AEWMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override int NPCType => ModContent.NPCType<PrimordialWyrmHead>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("PrimordialWyrm");
        public override int VanillaMusic => MusicID.Boss3;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
    }
}
