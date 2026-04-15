using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class FieryDraconidBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<FieryDraconid>();

        protected override ref bool MinionBool => ref BuffModdedOwner.aChicken;
    }
}
