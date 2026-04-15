using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class HydrothermicVentBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<HydrothermicVent>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cSpirit;
    }
}
