using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.UI.DraedonLogs
{
    public class DraedonLogPlanetoidGUI : DraedonsLogGUI
    {
        public override int TotalPages => 3;
        public override string GetTextByPage()
        {
            return CalamityUtils.GetTextValueFromModItem<DraedonsLogPlanetoid>("ContentPage" + (Page + 1));
        }
        public override Texture2D GetTextureByPage()
        {
            switch (Page)
            {
                case 0:
                    return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogPlanetoid").Value;
                case 1:
                    return null;
                default:
                    return ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/UI/DraedonLogs/DraedonsLogDoGArmor").Value;
            }
        }
    }
}
