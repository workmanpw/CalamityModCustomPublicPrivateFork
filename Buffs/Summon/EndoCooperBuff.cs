using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class EndoCooperBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<EndoCooperBody>();

        protected override ref bool MinionBool => ref BuffModdedOwner.endoCooper;
    }
}
