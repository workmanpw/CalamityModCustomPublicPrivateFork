using CalamityModCustomPublicPrivateFork.NPCs.SupremeCalamitas;
using CalamityModCustomPublicPrivateFork.Skies;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class SCalBackgroundScene : ModSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool IsSceneEffectActive(Player player) => NPC.AnyNPCs(ModContent.NPCType<SupremeCalamitas>()) || SCalSky.OverridingIntensity > 0f;

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("CalamityMod:SupremeCalamitas", isActive);
        }
    }
}
