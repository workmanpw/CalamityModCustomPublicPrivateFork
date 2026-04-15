using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CloudElemental : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CloudElementalMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cloudEleBuff;
    }
}
