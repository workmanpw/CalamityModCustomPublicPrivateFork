using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class LiliesOfFinalityBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<LiliesOfFinalityElster>();

        protected override ref bool MinionBool => ref BuffModdedOwner.LiliesOfFinalityBool;
    }
}
