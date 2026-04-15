using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BrittleStar : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<BrittleStarMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.brittleStar;
    }
}
