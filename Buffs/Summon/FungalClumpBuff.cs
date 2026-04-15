using CalamityModCustomPublicPrivateFork.Projectiles.Typeless;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class FungalClumpBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<FungalClumpMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.fClump;
    }
}
