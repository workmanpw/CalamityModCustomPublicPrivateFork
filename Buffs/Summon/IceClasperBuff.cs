using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class IceClasperBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<IceClasperMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.IceClasperBool;
    }
}
