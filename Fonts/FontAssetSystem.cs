using ReLogic.Content;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CalamityMod.Fonts
{
    public sealed class FontAssetSystem : ModSystem
    {
        public static Asset<DynamicSpriteFont> MouseText => FontAssets.MouseText;

        public static Asset<DynamicSpriteFont> ItemStack => FontAssets.ItemStack;

        public static Asset<DynamicSpriteFont> DeathText => FontAssets.DeathText;

        public static Asset<DynamicSpriteFont> CombatText => FontAssets.CombatText[0];

        public static Asset<DynamicSpriteFont> CombatTextCrit => FontAssets.CombatText[1];

        private static Asset<DynamicSpriteFont> _codebreakerDialog;
        public static Asset<DynamicSpriteFont> CodebreakerDialog => _codebreakerDialog ??= GetFont("Fonts/CodebreakerDialog");

        private static Asset<DynamicSpriteFont> _impact;
        public static Asset<DynamicSpriteFont> Impact => _impact ??= GetFont("Fonts/Impact");

        private static Asset<DynamicSpriteFont> _flexure;
        public static Asset<DynamicSpriteFont> Flexure => _flexure ??= GetFont("Fonts/Flexure");

        private static Asset<DynamicSpriteFont> GetFont(string path)
        {
            return ModContent.GetInstance<CalamityMod>().Assets.Request<DynamicSpriteFont>(path, AssetRequestMode.ImmediateLoad);
        }
    }
}
