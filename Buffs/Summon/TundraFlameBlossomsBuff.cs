using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class TundraFlameBlossomsBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<TundraFlameBlossom>();

        protected override ref bool MinionBool => ref BuffModdedOwner.tundraFlameBlossom;
    }
}
