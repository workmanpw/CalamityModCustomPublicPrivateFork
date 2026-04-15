using CalamityModCustomPublicPrivateFork.Items.DraedonMisc;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Tiles.DraedonStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.DraedonStructures
{
    public class AgedLaboratoryElectricPanelItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AgedLaboratoryElectricPanel>());
            Item.value = Item.sellPrice(silver: 1);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<RustedPlating>(7).
                AddIngredient<DubiousPlating>().
                AddIngredient<DraedonPowerCell>(4).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
