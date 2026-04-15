using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class VoidEaterMarionetteBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<VoidEaterMarionetteProjectile>();

        protected override ref bool MinionBool => ref BuffModdedOwner.hasVoidEaterMarionette;
    }
}
