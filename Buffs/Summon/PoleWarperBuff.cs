using CalamityModCustomPublicPrivateFork.Projectiles.DraedonsArsenal;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class PoleWarperBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PoleWarperSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.poleWarper;
    }
}
