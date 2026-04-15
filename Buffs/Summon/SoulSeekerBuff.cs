using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SoulSeekerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SeekerSummonProj>();

        protected override ref bool MinionBool => ref BuffModdedOwner.soulSeeker;
    }
}
