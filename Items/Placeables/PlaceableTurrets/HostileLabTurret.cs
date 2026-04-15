using System;
using System.Collections.Generic;
using CalamityModCustomPublicPrivateFork.CustomRecipes;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.PlaceableTurrets
{
    public class HostileLabTurret : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override string Texture => "CalamityModCustomPublicPrivateFork/Items/Placeables/PlaceableTurrets/LabTurret";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.DraedonStructures.DraedonLabTurret>());

            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Orange;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => CalamityGlobalItem.InsertKnowledgeTooltip(tooltips, 1);
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<MysteriousCircuitry>(14).
                AddIngredient<DubiousPlating>(20).
                AddCondition(ArsenalTierGatedRecipe.ConstructRecipeCondition(1, out Func<bool> condition), condition).
                AddCondition(Condition.InGraveyard).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
