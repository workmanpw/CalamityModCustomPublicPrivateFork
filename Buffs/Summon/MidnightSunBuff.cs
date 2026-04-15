using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class MidnightSunBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<MidnightSunUFO>();

        protected override ref bool MinionBool => ref BuffModdedOwner.midnightUFO;
    }
}
