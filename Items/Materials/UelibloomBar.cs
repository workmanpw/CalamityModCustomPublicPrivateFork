using CalamityModCustomPublicPrivateFork.Items.Placeables.Ores;
using CalamityModCustomPublicPrivateFork.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Materials
{
    [LegacyName("UeliaceBar")]
    public class UelibloomBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Materials";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
            ItemID.Sets.SortingPriorityMaterials[Type] = 106;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.UelibloomBar>());
            Item.value = Item.sellPrice(gold: 1, silver: 40);
            Item.rare = ModContent.RarityType<Turquoise>();
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<UelibloomOre>(4).
                AddTile(TileID.AdamantiteForge).
                Register();
        }
    }
}
