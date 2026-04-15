using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class PuffWarriorBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PuffWarrior>();

        protected override ref bool MinionBool => ref BuffModdedOwner.puffWarrior;
    }
}
