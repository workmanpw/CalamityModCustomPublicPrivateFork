using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class AstralProbeBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<AstralProbeSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.astralProbe;
    }
}
