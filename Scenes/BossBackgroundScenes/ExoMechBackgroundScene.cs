using CalamityModCustomPublicPrivateFork.Skies;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems
{
    public class ExoMechBackgroundScene : ModSceneEffect
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool IsSceneEffectActive(Player player) => ExoMechsSky.CanSkyBeActive || player.Calamity().monolithExoShader > 0;

        public override void SpecialVisuals(Player player, bool isActive)
        {
            player.ManageSpecialBiomeVisuals("CalamityMod:ExoMechs", isActive);
            if (isActive)
                SkyManager.Instance.Activate("CalamityMod:ExoMechs", player.Center);
            else
                SkyManager.Instance.Deactivate("CalamityMod:ExoMechs");
        }
    }
}
