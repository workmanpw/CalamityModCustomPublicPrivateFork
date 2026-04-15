using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class DankCreeperBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<DankCreeperMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.dCreeper;
    }
}
