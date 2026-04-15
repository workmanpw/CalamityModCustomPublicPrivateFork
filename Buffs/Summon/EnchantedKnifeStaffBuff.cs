using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class EnchantedKnifeStaffBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<EnchantedKnifeSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.EnchantedKnifeStaffBool;
    }
}
