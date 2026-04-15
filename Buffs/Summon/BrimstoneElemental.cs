using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BrimstoneElemental : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<BrimstoneElementalMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.brimEleBuff;
    }
}
