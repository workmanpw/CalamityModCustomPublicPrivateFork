using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CalamityModCustomPublicPrivateFork.UI.DialogueDisplay.DisplayEffects;

namespace CalamityModCustomPublicPrivateFork.UI.DialogueDisplay
{
    public class DialogueDisplayDebugItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Debug";
        public override string Texture => "CalamityModCustomPublicPrivateFork/Items/Weapons/Summon/StaffOfNecrosteocytes";
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 29;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }
        public override bool? UseItem(Player player)
        {
            int slot = DialogueDisplaySystem.GetSlot("OceanBlue");

            if (slot != -1)
                DialogueDisplaySystem.ProgressDialogue(slot);
            else
                DialogueDisplaySystem.StartDialogue("OceanBlue", player.Center, 0, -1, effects: new WhisperingPearlEffects());

            return true;
        }
    }
}
