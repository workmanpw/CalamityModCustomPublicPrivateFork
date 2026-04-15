using CalamityModCustomPublicPrivateFork.CalPlayer;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.Cooldowns
{
    public class SilvaRevive : CooldownHandler
    {
        public static new string ID => "SilvaRevive";
        public override bool ShouldDisplay => true;
        public override LocalizedText DisplayName => CalamityUtils.GetText($"UI.Cooldowns.{ID}");
        public override string Texture => "CalamityModCustomPublicPrivateFork/Cooldowns/SilvaRevive";
        public override Color OutlineColor => new Color(151, 211, 152);
        public override Color CooldownStartColor => new Color(226, 188, 74);
        public override Color CooldownEndColor => new Color(151, 211, 152);

        public override bool CanTickDown => !CalamityPlayer.areThereAnyDamnBosses && !CalamityPlayer.areThereAnyDamnEvents;
    }
}
