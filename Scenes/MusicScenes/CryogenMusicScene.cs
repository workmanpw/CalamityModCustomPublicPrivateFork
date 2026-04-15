using CalamityModCustomPublicPrivateFork.NPCs.Cryogen;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class CryogenMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<Cryogen>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("Cryogen");
        public override int VanillaMusic => MusicID.FrostMoon;
        public override int OtherworldMusic => MusicID.OtherworldlyIce;
    }
}
