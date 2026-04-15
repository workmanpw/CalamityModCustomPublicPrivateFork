using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class Herring : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<HerringAI>();

        protected override ref bool MinionBool => ref BuffModdedOwner.herring;
    }
}
