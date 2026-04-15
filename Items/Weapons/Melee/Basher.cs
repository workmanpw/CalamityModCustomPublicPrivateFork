using CalamityModCustomPublicPrivateFork.Items.BaseItems;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Placeables.FurnitureAcidwood;
using CalamityModCustomPublicPrivateFork.Projectiles.Melee;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Weapons.Melee
{
    public class Basher : CustomUseProjItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Weapons.Melee";
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 60;
            Item.damage = 40;
            Item.DamageType = TrueMeleeDamageClass.Instance;
            Item.useAnimation = Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7f;
            Item.autoReuse = true;

            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<BasherHoldout>();
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = CalamityGlobalItem.RarityBlueBuyPrice;
            Item.rare = ItemRarityID.Blue;
        }
        public override bool MeleePrefix() => true;
        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<Acidwood>(15).
                AddIngredient<SulphuricScale>(12).
                AddTile(TileID.Anvils).
                Register();
        }
    }
}
