using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class LilPlaguebringerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PlaguebringerSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.plaguebringerPatronSummon;
    }
}
