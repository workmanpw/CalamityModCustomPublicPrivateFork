using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class EyeOfNightBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<EyeOfNightSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.eyeOfNight;
    }
}
