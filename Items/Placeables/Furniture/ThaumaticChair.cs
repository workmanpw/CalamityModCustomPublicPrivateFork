using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAbyss;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAcidwood;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAncient;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAshen;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureBotanic;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureCosmilite;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureNavystone;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureExo;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureMarnite;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureMonolith;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureOtherworldly;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurniturePlagued;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureProfaned;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureSacrilegious;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureSilva;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureStatigel;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureStratus;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureVoid;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureWulfrum;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture
{
    public class ThaumaticChair : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ThaumaticChairTile>());
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ModContent.RarityType<BurnishedAuric>();
            Item.Calamity().donorItem = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
            AddIngredient<AbyssChair>().
            AddIngredient<AcidwoodChair>().
            AddIngredient<AncientChair>().
            AddIngredient<AshenChair>().
            AddIngredient<BotanicChair>().
            AddIngredient<CosmiliteChair>().
            AddIngredient<NavystoneChair>().
            AddIngredient<ExoChair>().
            AddIngredient<MarniteChair>().
            AddIngredient<MonolithChair>().
            AddIngredient<SacrilegiousChair>().
            AddIngredient<OtherworldlyChair>().
            AddIngredient<PlaguedPlateChair>().
            AddIngredient<ProfanedChair>().
            AddIngredient<SilvaChair>().
            AddIngredient<StatigelChair>().
            AddIngredient<StratusChair>().
            AddIngredient<VoidChair>().
            AddIngredient<WulfrumChair>().
            AddIngredient<AuricBar>().
            AddTile<CosmicAnvil>().
            Register();
        }
    }
}
