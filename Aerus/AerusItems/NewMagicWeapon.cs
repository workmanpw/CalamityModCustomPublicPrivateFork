using System;

using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

using Terraria;

using Terraria.DataStructures;

using Terraria.GameContent;

using Terraria.ID;

using Terraria.ModLoader;



namespace CelestialCalamityAerus

{

    public class CelestialStaff : ModItem

    {

        public override string Texture => "CelestialCalamityAerus/Aerus/NewMagicWeapon";



        public override void SetStaticDefaults()

        {

            // DisplayName.SetDefault("Celestial Staff");

            // Tooltip.SetDefault("Calls down celestial beams from the sky\n'Harness the power of the stars'");

        }



        public override void SetDefaults()

        {

            Item.width = 40;

            Item.height = 40;

            Item.damage = 85;

            Item.DamageType = DamageClass.Magic;

            Item.mana = 2;

            Item.useTime = 5;

            Item.useAnimation = 20;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;

            Item.knockBack = 6f;

            Item.value = 10000;

            Item.rare = ItemRarityID.LightRed;

            Item.autoReuse = true;

            Item.shoot = ProjectileID.MagicMissile;

            Item.shootSpeed = 12f;

        }



        public override void ModifyTooltips(List<TooltipLine> list)

        {

            // Add custom tooltip

            list.Add(new TooltipLine(Mod, "Tooltip0", "A powerful celestial weapon\nRight click for special ability\n'Harness the power of the stars'"));

        }



        public override bool AltFunctionUse(Player player)

        {

            return true; // Enable right-click functionality

        }



        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)

        {

            // Check if this is a right-click (alt function use)

            if (player.altFunctionUse == 2)

            {

                // Right-click: Burst of celestial beams with random effects

                ShootCelestialBurst(player, source, damage, knockback);

                return false;

            }

            

            // Left-click: Vivid Clarity style beam spawning

            Vector2 playerPos = player.RotatedRelativePoint(player.MountedCenter, true);

            float speed = Item.shootSpeed;

            float xPos = (float)Main.mouseX + Main.screenPosition.X - playerPos.X;

            float yPos = (float)Main.mouseY + Main.screenPosition.Y - playerPos.Y;

            float f = Main.rand.NextFloat() * MathHelper.TwoPi;

            float sourceVariationLow = 20f;

            float sourceVariationHigh = 60f;

            Vector2 spawnSource = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());

            

            for (int i = 0; i < 50; i++)

            {

                spawnSource = playerPos + f.ToRotationVector2() * MathHelper.Lerp(sourceVariationLow, sourceVariationHigh, Main.rand.NextFloat());

                if (Collision.CanHit(playerPos, 0, 0, spawnSource + (spawnSource - playerPos).SafeNormalize(Vector2.UnitX) * 8f, 0, 0))

                {

                    break;

                }

                f = Main.rand.NextFloat() * MathHelper.TwoPi;

            }

            

            Vector2 velocityReal = Main.MouseWorld - spawnSource;

            Vector2 velocityVariation = new Vector2(xPos, yPos).SafeNormalize(Vector2.UnitY) * speed;

            velocityReal = velocityReal.SafeNormalize(velocityVariation) * speed;

            velocityReal = Vector2.Lerp(velocityReal, velocityVariation, 0.25f);

            

            Projectile.NewProjectile(source, spawnSource, velocityReal, type, damage, knockback, player.whoAmI, 0f, Main.rand.Next(3));

            return false;

        }



        private void ShootCelestialBurst(Player player, EntitySource_ItemUse_WithAmmo source, int damage, float knockback)

        {

            // Create a burst of celestial beams with all three effects

            int projectileCount = 12;

            float spreadAngle = MathHelper.TwoPi / projectileCount;

            

            for (int i = 0; i < projectileCount; i++)

            {

                float angle = spreadAngle * i;

                Vector2 velocity = angle.ToRotationVector2() * 8f;

                

                // Add some randomness

                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                

                // Random effect type (0, 1, or 2)

                int effectType = Main.rand.Next(3);

                

                Projectile.NewProjectile(

                    source,

                    player.Center,

                    velocity,

                    ProjectileID.MagicMissile,

                    damage,

                    knockback,

                    player.whoAmI,

                    0f,

                    effectType

                );

            }



            // Create visual burst effect

            for (int i = 0; i < 20; i++)

            {

                Dust dust = Dust.NewDustPerfect(player.Center, DustID.GoldFlame);

                dust.velocity = (MathHelper.TwoPi * i / 20f).ToRotationVector2() * 4f;

                dust.scale = 1.2f;

                dust.noGravity = true;

                dust.color = new Color(255, 215, 0);

            }

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Apply CelestialFlames debuff to target
            target.AddBuff(ModContent.BuffType<Buffs.Aerus.CelestialFlames>(), 300);
        }

        public override void AddRecipes()

        {

            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.FallenStar, 10);

            recipe.AddIngredient(ItemID.ManaCrystal, 5);

            recipe.AddTile(TileID.Anvils);

            recipe.Register();

        }



        public override void PostUpdate()

        {

            // Add some visual glow effect when held

            if (Main.rand.NextBool(3))

            {

                Dust dust = Dust.NewDustPerfect(Item.Center, DustID.GoldFlame);

                dust.velocity = Vector2.UnitY * -0.5f;

                dust.scale = 0.8f;

                dust.noGravity = true;

            }

        }

    }

}

