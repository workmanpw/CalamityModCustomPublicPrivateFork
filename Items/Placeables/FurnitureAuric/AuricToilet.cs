using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureBotanic;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureCosmilite;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureSilva;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAuric;
using Terraria;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAuric
{
    public class AuricToilet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AuricToiletTile>());
            Item.value = Item.sellPrice(gold: 40);
            Item.rare = ModContent.RarityType<BurnishedAuric>(); // Most special shitter gets most preferential treatment
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<BotanicChair>().
                AddIngredient<CosmiliteChair>().
                AddIngredient<SilvaChair>().
                AddIngredient<AuricBar>(5).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
