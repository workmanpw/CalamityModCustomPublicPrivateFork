using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class WulfrumDroidBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<WulfrumDroid>();

        protected override ref bool MinionBool => ref BuffModdedOwner.wDroid;
    }
}
