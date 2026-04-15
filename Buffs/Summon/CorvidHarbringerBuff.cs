using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class CorvidHarbringerBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<PowerfulRaven>();

        protected override ref bool MinionBool => ref BuffModdedOwner.powerfulRaven;
    }
}
