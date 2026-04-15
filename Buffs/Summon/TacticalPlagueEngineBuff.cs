using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class TacticalPlagueEngineBuff : BaseSummonBuff
    {
        protected override int MinionProjectileType => ModContent.ProjectileType<TacticalPlagueJet>();

        protected override ref bool MinionBool => ref BuffModdedOwner.plagueEngine;
    }
}
