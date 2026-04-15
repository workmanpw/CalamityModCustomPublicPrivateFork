using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class BrimseekerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<DormantBrimseekerBab>();

        protected override ref bool MinionBool => ref BuffModdedOwner.brimseeker;
    }
}
