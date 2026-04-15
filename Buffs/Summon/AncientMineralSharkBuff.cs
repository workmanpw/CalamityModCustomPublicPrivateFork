using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class AncientMineralSharkBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<ApexShark>();

        protected override ref bool MinionBool => ref BuffModdedOwner.apexShark;
    }
}
