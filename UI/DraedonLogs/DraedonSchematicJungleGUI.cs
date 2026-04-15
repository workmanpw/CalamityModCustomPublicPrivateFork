using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.UI.DraedonLogs
{
    public class DraedonSchematicJungleGUI : DraedonsLogGUI
    {
        public override int TotalPages => 1;
        public override string GetTextByPage()
        {
            return CalamityUtils.GetTextValueFromModItem<EncryptedSchematicJungle>("Content");
        }
        public override Texture2D GetTextureByPage()
        {
            return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogJungleBiome").Value;
        }
    }
}
