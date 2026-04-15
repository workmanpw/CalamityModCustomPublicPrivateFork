using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Placeables.Ores
{
    public class AuricOre : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Placeables";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SortingPriorityMaterials[Type] = 119;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Ores.AuricOre>());
            Item.value = Item.sellPrice(silver: 60);
            Item.rare = ModContent.RarityType<BurnishedAuric>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(10).
                AddIngredient<YharonSoulFragment>().
                AddCondition(Condition.NearShimmer).
                Register();
        }
    }
}
