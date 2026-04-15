using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class HowlTrio : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<HowlsHeartHowl>();

        protected override ref bool MinionBool => ref BuffModdedOwner.howlTrio;
    }
}
