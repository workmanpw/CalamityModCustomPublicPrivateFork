using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class EntropysVigilBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<Calamitamini>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cEyes;
    }
}
