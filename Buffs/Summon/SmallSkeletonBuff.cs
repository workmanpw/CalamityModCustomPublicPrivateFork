using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SmallSkeletonBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SmallSkeletonMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.necrosteocytesDudes;
    }
}
