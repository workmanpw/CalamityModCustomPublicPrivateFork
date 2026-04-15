using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Projectiles.Rogue;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue
{
    public class Supernova : RogueWeapon
    {
        public static readonly SoundStyle ExplosionSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/SupernovaBoom") { Volume = 0.9f };
        public static readonly SoundStyle StealthExplosionSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/SupernovaStealthExplode") { Volume = 1f };
        public static readonly SoundStyle StealthChargeSound = new("CalamityModCustomPublicPrivateFork/Sounds/Item/SupernovaStealthCharge") { Volume = 1f };
        public override void SetDefaults()
        {
            Item.width = 106;
            Item.height = 112;
            Item.damage = 5036;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.knockBack = 18f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.value = CalamityGlobalItem.RarityVioletBuyPrice;
            Item.shoot = ModContent.ProjectileType<SupernovaBomb>();
            Item.shootSpeed = 16f;
            Item.DamageType = RogueDamageClass.Instance;
            Item.rare = ModContent.RarityType<BurnishedAuric>();
        }

        public override float StealthDamageMultiplier => 0.7f;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.Calamity().StealthStrikeAvailable()) //setting the stealth strike
            {
                int stealth = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                if (stealth.WithinBounds(Main.maxProjectiles))
                    Main.projectile[stealth].Calamity().stealthStrike = true;
                return false;
            }
            else
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Item.DrawItemGlowmaskSingleFrame(spriteBatch, rotation, ModContent.Request<Texture2D>("CalamityModCustomPublicPrivateFork/Items/Weapons/Rogue/SupernovaGlow").Value);
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<SealedSingularity>().
                AddIngredient<StarofDestruction>().
                AddIngredient<TotalityBreakers>().
                AddIngredient<BallisticPoisonBomb>().
                AddIngredient<MiracleMatter>().
                AddTile<DraedonsForge>().
                Register();
        }
    }
}
