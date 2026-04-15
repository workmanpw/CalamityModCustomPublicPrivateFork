using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAuric;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAuric
{
    public class AuricRepulserPanel : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }
        public override void SetDefaults() => Item.DefaultToPlaceableTile(ModContent.TileType<AuricRepulserPanelTile>());

        public override void AddRecipes()
        {
            CreateRecipe(400).
                AddIngredient<ActivatedAuricPanel>(400).
                AddIngredient<AscendantSpiritEssence>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
