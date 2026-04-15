using CalamityModCustomPublicPrivateFork.NPCs.Crabulon;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class DrunkCrabBackgroundScene : ModSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool IsSceneEffectActive(Player player)
        {
            if (Main.zenithWorld && NPC.AnyNPCs(ModContent.NPCType<Crabulon>()))
                return true;
            return false;
        }

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("CalamityMod:DrunkCrabulon", isActive);
        }
    }
}
