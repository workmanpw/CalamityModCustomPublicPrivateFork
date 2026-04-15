using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class PlantationStaffBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PlantationStaffSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.PlantationSummon;
    }
}
