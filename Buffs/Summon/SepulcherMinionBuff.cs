using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SepulcherMinionBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SepulcherMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sepulcher;
    }
}
