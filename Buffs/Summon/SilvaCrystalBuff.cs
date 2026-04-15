using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SilvaCrystalBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SilvaCrystal>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sCrystal;
    }
}
