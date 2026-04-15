using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BabyBloodCrawlerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<BabyBloodCrawler>();

        protected override ref bool MinionBool => ref BuffModdedOwner.scabRipper;
    }
}
