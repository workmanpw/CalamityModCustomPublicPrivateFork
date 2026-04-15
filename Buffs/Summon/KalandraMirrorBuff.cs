using CalamityModCustomPublicPrivateFork.Projectiles.Summon.MirrorofKalandraMinions;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class KalandraMirrorBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<AtzirisDisfavor>();

        protected override ref bool MinionBool => ref BuffModdedOwner.KalandraMirror;
    }
}
