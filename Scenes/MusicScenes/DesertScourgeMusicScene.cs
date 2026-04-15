using CalamityModCustomPublicPrivateFork.NPCs.DesertScourge;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class DesertScourgeMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossMedium;

        public override int NPCType => ModContent.NPCType<DesertScourgeHead>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("DesertScourge");
        public override int VanillaMusic => MusicID.Boss1;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss1;
        public override int[] AdditionalNPCs => new int[]
        {
            ModContent.NPCType<DesertScourgeBody>(),
            ModContent.NPCType<DesertScourgeTail>()
        };
    }
}
