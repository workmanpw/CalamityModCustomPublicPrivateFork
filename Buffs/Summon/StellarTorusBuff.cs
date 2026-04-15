using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class StellarTorusBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<StellarTorusSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.StellarTorus;
    }
}
