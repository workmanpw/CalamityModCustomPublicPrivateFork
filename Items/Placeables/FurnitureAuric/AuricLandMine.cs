using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using CalamityModCustomPublicPrivateFork.Tiles.FurnitureAuric;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAuric
{
    public class AuricLandMine : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
            // Did you know Land Mines can be placed on Weapon Racks? Yeah, me neither.
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AuricLandMineTile>());
            Item.value = Item.sellPrice(gold: 1);
            Item.mech = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(50).
                AddIngredient(ItemID.LandMine, 50).
                AddIngredient<AuricBar>().
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
