using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class HauntedDishesBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<HauntedDishes>();

        protected override ref bool MinionBool => ref BuffModdedOwner.hauntedDishes;
    }
}
