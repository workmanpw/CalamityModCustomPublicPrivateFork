using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class FrostBlossomBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<FrostBlossom>();

        protected override ref bool MinionBool => ref BuffModdedOwner.frostBlossom;
    }
}
