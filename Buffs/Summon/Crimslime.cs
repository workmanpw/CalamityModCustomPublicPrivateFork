using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class Crimslime : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CrimslimeMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cSlime2;
    }
}
