using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SiriusBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SiriusMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sirius;
    }
}
