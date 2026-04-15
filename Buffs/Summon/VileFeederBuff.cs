using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class VileFeederBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<VileFeederSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.vileFeeder;
    }
}
