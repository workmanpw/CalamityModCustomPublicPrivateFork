using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class KingofConstellationsBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<BlackDragonHead>();

        protected override ref bool MinionBool => ref BuffModdedOwner.celestialDragons;
    }
}
