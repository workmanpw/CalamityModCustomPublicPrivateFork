using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CosmilampBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CosmilampMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.cLamp;
    }
}
