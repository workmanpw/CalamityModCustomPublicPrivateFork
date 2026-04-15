using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.UI.DraedonLogs
{
    public class DraedonSchematicSunkenSeaGUI : DraedonsLogGUI
    {
        public override int TotalPages => 1;
        public override string GetTextByPage()
        {
            return CalamityUtils.GetTextValueFromModItem<EncryptedSchematicSunkenSea>("Content");
        }
        public override Texture2D GetTextureByPage()
        {
            return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogSunkenSeaBiome").Value;
        }
    }
}
