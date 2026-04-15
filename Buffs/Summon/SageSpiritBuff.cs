using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SageSpiritBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SageSpirit>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sageSpirit;
    }
}
