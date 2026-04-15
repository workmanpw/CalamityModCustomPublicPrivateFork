using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class DaedalusCrystalBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<DaedalusCrystal>();

        protected override ref bool MinionBool => ref BuffModdedOwner.dCrystal;
    }
}
