using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SkeletalDragonsBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SkeletalDragonMother>();

        protected override ref bool MinionBool => ref BuffModdedOwner.dragonFamily;
    }
}
