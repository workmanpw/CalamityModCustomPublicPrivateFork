using CalamityModCustomPublicPrivateFork.NPCs;
using CalamityModCustomPublicPrivateFork.NPCs.ExoMechs;
using CalamityModCustomPublicPrivateFork.NPCs.ExoMechs.Apollo;
using CalamityModCustomPublicPrivateFork.NPCs.ExoMechs.Ares;
using CalamityModCustomPublicPrivateFork.NPCs.ExoMechs.Artemis;
using CalamityModCustomPublicPrivateFork.NPCs.ExoMechs.Thanatos;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class ExoMechsMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override int NPCType => ModContent.NPCType<Draedon>();
        public override int? MusicModMusic => ModContent.GetInstance<CalamityMod>().GetMusicFromMusicMod("ExoMechs");
        public override int VanillaMusic => MusicID.Boss3;
        public override int OtherworldMusic => MusicID.OtherworldlyBoss2;
        public override int[] AdditionalNPCs => new int[]
        {
            ModContent.NPCType<Apollo>(),
            ModContent.NPCType<AresBody>(),
            ModContent.NPCType<Artemis>(),
            ModContent.NPCType<ThanatosHead>(),
            ModContent.NPCType<ThanatosBody1>(),
            ModContent.NPCType<ThanatosBody2>(),
            ModContent.NPCType<ThanatosTail>()
        };

        public override bool AdditionalCheck() => CalamityGlobalNPC.draedonAmbience == -1;
    }
}
