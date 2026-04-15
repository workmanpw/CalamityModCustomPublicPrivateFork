using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class WitherBlossomsBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<WitherBlossom>();

        protected override ref bool MinionBool => ref BuffModdedOwner.witherBlossom;
    }
}
