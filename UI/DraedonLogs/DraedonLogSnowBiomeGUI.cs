using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.UI.DraedonLogs
{
    public class DraedonLogSnowBiomeGUI : DraedonsLogGUI
    {
        public override int TotalPages => 3;
        public override string GetTextByPage()
        {
            return CalamityUtils.GetTextValueFromModItem<DraedonsLogSnowBiome>("ContentPage" + (Page + 1));
        }
        public override Texture2D GetTextureByPage()
        {
            switch (Page)
            {
                case 0:
                    return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogIceBiome").Value;
                case 1:
                    return null;
                default:
                    return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogPermafrost").Value;
            }
        }
    }
}
