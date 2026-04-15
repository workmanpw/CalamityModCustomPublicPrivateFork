using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Fishing
{
    internal class SkylineBobber : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Fishing";
        public override string Texture => "CalamityModCustomPublicPrivateFork/Projectiles/Typeless/HeronBobber";
        public override void SetDefaults()
        {
            Item.width = 9;
            Item.height = 9;
            Item.value = CalamityGlobalItem.RarityOrangeBuyPrice;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.accFishingBobber = true;
            player.Calamity().SelectedFishingMinigame = CalamityPlayer.FishingMinigames.SkylineBobber;
        }
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.FishingBobber).
                AddIngredient<AerialiteBar>(5).
                AddIngredient(ItemID.Feather).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
