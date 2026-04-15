using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.UI;
using CalamityModCustomPublicPrivateFork.UI.DraedonLogs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.DraedonMisc
{
    public class DraedonsLogPlanetoid : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.DraedonItems";
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<DarkOrange>();
            Item.useAnimation = Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
                PopupGUIManager.FlipActivityOfGUIWithType(typeof(DraedonLogPlanetoidGUI));
            return true;
        }
    }
}
