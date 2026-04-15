using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.Cooldowns
{
    public class AscendEffect : CooldownHandler
    {
        public static new string ID => "AscendEffect";
        public override bool ShouldDisplay => true;
        public override LocalizedText DisplayName => CalamityUtils.GetText($"UI.Cooldowns.{ID}");
        public override string Texture => "CalamityModCustomPublicPrivateFork/Cooldowns/AscendEffect";
        public override Color OutlineColor => new Color(197, 165, 108);
        public override Color CooldownStartColor => new Color(144, 84, 29);
        public override Color CooldownEndColor => Color.Khaki;

        public override SoundStyle? EndSound => new("CalamityModCustomPublicPrivateFork/Sounds/Item/AscendantOff");
    }
}
