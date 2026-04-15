using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.CalPlayer.Dashes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.SunkenSea;

namespace CalamityModCustomPublicPrivateFork.Items.Accessories
{
    public class DeepDiver : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Accessories";
        public const int ShieldSlamDamage = 35;
        public const float ShieldSlamKnockback = 0.2f;
        public const int ShieldSlamIFrames = 16;
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = CalamityGlobalItem.RarityLightRedBuyPrice;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalamityPlayer modPlayer = player.Calamity();
            modPlayer.deepDiver = true;
            modPlayer.DashID = DeepDiverDash.ID;
            player.dashType = 0;
            player.ignoreWater = true; // Mobility in water
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SeaPrism>(25).
                AddIngredient<MolluskHusk>(5).
                AddRecipeGroup("AnyCobaltBar", 10).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
