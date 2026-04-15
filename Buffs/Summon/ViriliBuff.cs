using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class ViriliBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PlaguePrincess>();

        protected override ref bool MinionBool => ref BuffModdedOwner.virili;
    }
}
