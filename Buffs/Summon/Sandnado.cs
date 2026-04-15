using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class Sandnado : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SandnadoMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sandnado;
    }
}
