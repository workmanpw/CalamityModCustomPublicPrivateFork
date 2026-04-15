using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Potions;
using CalamityModCustomPublicPrivateFork.Tiles.Astral;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture
{
    public class AstralBeaconItem : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<AstralBeacon>());
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<AureusCell>(5).
                AddIngredient<StarblightSoot>(20).
                AddIngredient<Items.Placeables.Astral.AstralStone>(30).
                AddTile(TileID.HeavyWorkBench).
                Register();
        }
    }
}
