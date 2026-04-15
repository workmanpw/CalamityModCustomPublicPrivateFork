using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Trophies;
using CalamityModCustomPublicPrivateFork.Rarities;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.LoreItems
{
    [LegacyName("KnowledgeSentinels")]
    public class LoreCeaselessVoid : LoreItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.consumable = false;
            Item.rare = ModContent.RarityType<Turquoise>();
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<CeaselessVoidTrophy>().
                AddTile(TileID.Bookcases).
                Register();
        }
    }
}
