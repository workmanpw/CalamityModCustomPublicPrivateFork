using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CosmicEnergy : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CosmicEnergySpiral>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cEnergy;
    }
}
