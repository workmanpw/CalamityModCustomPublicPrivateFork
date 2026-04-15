using CalamityModCustomPublicPrivateFork.Projectiles.DraedonsArsenal;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class AqueousHunterDroneBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<AqueousHunterDroneSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.aqueousHunterDrone;
    }
}
