using CalamityModCustomPublicPrivateFork.NPCs.Polterghast;
using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class PolterghastSilentMusicScene : BaseMusicSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public int SilentMusicSlot => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Silence");

        public override int NPCType => ModContent.NPCType<Polterghast>();
        public override int? MusicModMusic => SilentMusicSlot;
        public override int VanillaMusic => SilentMusicSlot;
        public override int OtherworldMusic => SilentMusicSlot;
        public override int? ProjType => ModContent.ProjectileType<OldDukeHeadCorpse>();

        public override bool AdditionalCheck() => Main.zenithWorld;
    }
}
