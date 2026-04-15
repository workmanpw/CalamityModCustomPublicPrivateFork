using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class ShellfishBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<Shellfish>();

        protected override ref bool MinionBool => ref BuffModdedOwner.shellfish;
    }
}
