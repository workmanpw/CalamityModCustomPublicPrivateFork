using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class IgneousExaltationBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<IgneousBlade>();

        protected override ref bool MinionBool => ref BuffModdedOwner.igneousExaltation;
    }
}
