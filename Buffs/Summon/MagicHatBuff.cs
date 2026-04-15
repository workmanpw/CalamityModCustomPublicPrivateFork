using CalamityModCustomPublicPrivateFork.Projectiles.Summon.Umbrella;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class MagicHatBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<MagicHat>();

        protected override ref bool MinionBool => ref BuffModdedOwner.magicHat;
    }
}
