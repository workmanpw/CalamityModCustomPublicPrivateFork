using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class WaterElemental : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<WaterElementalMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.waterEleBuff;
    }
}
