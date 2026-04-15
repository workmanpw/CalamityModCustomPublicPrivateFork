using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SarosPossessionBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SarosAura>();

        protected override ref bool MinionBool => ref BuffModdedOwner.saros;
    }
}
