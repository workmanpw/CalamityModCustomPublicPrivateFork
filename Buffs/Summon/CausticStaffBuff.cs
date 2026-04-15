using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CausticStaffBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CausticStaffSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.causticDragon;
    }
}
