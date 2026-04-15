using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class MoonFistBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<MoonFist>();

        protected override ref bool MinionBool => ref BuffModdedOwner.MoonFist;
    }
}
