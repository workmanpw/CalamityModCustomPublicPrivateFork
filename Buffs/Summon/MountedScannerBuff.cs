using CalamityModCustomPublicPrivateFork.Projectiles.DraedonsArsenal;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class MountedScannerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<MountedScannerSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.mountedScanner;
    }
}
