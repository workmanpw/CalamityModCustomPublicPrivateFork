using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Accessories
{
    internal class NavystoneBobber : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Fishing";
        public override string Texture => "CalamityModCustomPublicPrivateFork/Projectiles/Typeless/NavyBobber";
        public override void SetDefaults()
        {
            Item.width = 9;
            Item.height = 9;
            Item.value = CalamityGlobalItem.RarityGreenBuyPrice;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accFishingBobber = true;
            player.Calamity().SelectedFishingMinigame = CalamityPlayer.FishingMinigames.NavystoneBobber;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.FishingBobber).
                AddIngredient<PearlShard>().
                AddIngredient<Navystone>(5).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
