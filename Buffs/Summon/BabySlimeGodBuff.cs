using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BabySlimeGodBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<CrimsonSlimeGodMinion>();

        protected override ref bool MinionBool => ref BuffModdedOwner.sGod;
    }
}
