using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CinderBlossomBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CinderBlossom>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cinderBlossom;
    }
}
