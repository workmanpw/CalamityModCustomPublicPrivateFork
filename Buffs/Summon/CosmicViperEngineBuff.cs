using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CosmicViperEngineBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CosmicViperSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cosmicViper;
    }
}
