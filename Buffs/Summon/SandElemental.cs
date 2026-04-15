using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SandElemental : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SandElementalMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sandEleBuff;
    }
}
