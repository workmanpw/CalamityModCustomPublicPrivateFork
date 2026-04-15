using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SolarSpirit : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SunSpiritMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sunSpirit;
    }
}
