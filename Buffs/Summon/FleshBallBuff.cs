using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class FleshBallBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<FleshBallMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.fleshBall;
    }
}
