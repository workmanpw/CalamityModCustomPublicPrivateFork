using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class RareSandElemental : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SandElementalHealer>();

        protected override ref bool MinionBool => ref BuffModdedOwner.rareSandEleBuff;
    }
}
