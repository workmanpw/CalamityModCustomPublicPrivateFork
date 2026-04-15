using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.Cooldowns
{
    public class ArsenalPower : CooldownHandler
    {
        public static new string ID => "ArsenalPower";
        public override bool ShouldDisplay => true;
        public override LocalizedText DisplayName => CalamityUtils.GetText($"UI.Cooldowns.{ID}");
        public override string Texture => "CalamityModCustomPublicPrivateFork/Cooldowns/ArsenalPower";
        public override Color OutlineColor => Color.White;
        public override Color CooldownStartColor => Color.Sienna;
        public override Color CooldownEndColor => Color.LightSlateGray;
        public override void Tick()
        {
            if (Main.zenithWorld)
                instance.timeLeft = -1;
            
        }

        public override SoundStyle? EndSound => (Main.zenithWorld ? null : new("CalamityModCustomPublicPrivateFork/Sounds/Item/ArsenalOffCooldown"));
    }
}
