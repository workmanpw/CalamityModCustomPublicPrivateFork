using System.Collections.Generic;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Armor.GemTech
{
    [AutoloadEquip(EquipType.Legs)]
    public class GemTechSchynbaulds : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Armor.PostMoonLord";
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 26;
            Item.defense = 24;
            Item.value = CalamityGlobalItem.RarityVioletBuyPrice;
            Item.rare = ModContent.RarityType<BurnishedAuric>();
            Item.Calamity().donorItem = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => GemTechHeadgear.ModifySetTooltips(this, tooltips);

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<ExoPrism>(12).
                AddIngredient<GalacticaSingularity>(4).
                AddIngredient<CoreofCalamity>(2).
                AddTile<DraedonsForge>().
                Register();
        }
    }
}
