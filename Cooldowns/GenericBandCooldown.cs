using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.Cooldowns
{
    public class GenericBandCooldown : CooldownHandler
    {
        public static new string ID => "BandCooldown";
        public override bool ShouldDisplay => true;
        public override LocalizedText DisplayName => CalamityUtils.GetText($"UI.Cooldowns.{ID}");
        public override string Texture => "CalamityModCustomPublicPrivateFork/Cooldowns/GenericBandCooldown";
        public override Color OutlineColor => Color.White;
        public override Color CooldownStartColor => Color.SlateGray;
        public override Color CooldownEndColor => Color.Gray;
    }
}
