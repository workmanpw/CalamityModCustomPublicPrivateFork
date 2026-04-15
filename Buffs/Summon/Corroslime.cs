using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class Corroslime : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CorroslimeMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cSlime;
    }
}
