using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BelladonnaSpiritBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<BelladonnaSpirit>();

        protected override ref bool MinionBool => ref BuffModdedOwner.belladonaSpirit;
    }
}
