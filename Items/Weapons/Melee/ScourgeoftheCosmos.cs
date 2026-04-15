using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Projectiles.Melee;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Weapons.Melee
{
    public class ScourgeoftheCosmos : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Melee";
        public override void SetDefaults()
        {
            Item.width = Item.height = 64;
            Item.damage = 380;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = Item.useTime = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item109;
            Item.autoReuse = true;
            Item.value = CalamityGlobalItem.RarityDarkBlueBuyPrice;
            Item.rare = ModContent.RarityType<CosmicPurple>();
            Item.shoot = ModContent.ProjectileType<ScourgeoftheCosmosProj>();
            Item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient(ItemID.ScourgeoftheCorruptor).
                AddIngredient<Bonebreaker>().
                AddIngredient<CosmiliteBar>(10).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
