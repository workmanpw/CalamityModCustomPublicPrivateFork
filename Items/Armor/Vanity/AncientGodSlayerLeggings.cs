using CalamityModCustomPublicPrivateFork.Rarities;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientGodSlayerLeggings : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.Vanity";
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.vanity = true;
            Item.value = Item.sellPrice(gold: 9);
            Item.rare = ModContent.RarityType<CosmicPurple>();
        }
    }
}
