using CalamityMod.NPCs.HiveMind;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityMod.Systems
{
    public class HiveMindMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<HiveMind>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("HiveMind");
        public override int VanillaMusic => MusicID.Boss2;
        public override int OtherworldMusic => MusicID.OtherworldlyWoF;
    }
}
