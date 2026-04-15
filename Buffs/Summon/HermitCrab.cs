using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class HermitCrab : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<HermitCrabMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.hCrab;
    }
}
