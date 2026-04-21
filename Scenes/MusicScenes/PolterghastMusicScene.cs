using CalamityMod.NPCs.Polterghast;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityMod.Systems
{
    public class PolterghastMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<Polterghast>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("Polterghast");
        public override int VanillaMusic => MusicID.Plantera;
        public override int OtherworldMusic => MusicID.OtherworldlyPlantera;

        public override bool AdditionalCheck() => !Main.zenithWorld;
    }
}
