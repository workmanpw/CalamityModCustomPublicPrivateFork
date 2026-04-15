using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class MutatedTruffleBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<MutatedTruffleMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.MutatedTruffleBool;
    }
}
