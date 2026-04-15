using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CalamarisLamentBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CalamarisLamentMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.CalamarisLament;
    }
}
