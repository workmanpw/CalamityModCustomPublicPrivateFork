using CalamityModCustomPublicPrivateFork.Projectiles.DraedonsArsenal;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class SnakeEyesBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<SnakeEyesSummon>();

        protected override ref bool MinionBool => ref BuffModdedOwner.snakeEyes;
    }
}
