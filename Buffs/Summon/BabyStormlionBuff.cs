using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BabyStormlionBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<StormjawBaby>();

        protected override ref bool MinionBool => ref BuffModdedOwner.stormjaw;
    }
}
