using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using CalamityMod.Aerus.AerusProjectiles;

namespace CalamityMod.Aerus
{
    // ── Main Mod Class ──────────────────────────────────────────────────────────
    public class CelestialAerusMod : ModSystem
    {
        public static ModKeybind SwitchModeKeybind;


        public override void Load()
        {
            if (!Main.dedServ)
            {
                SwitchModeKeybind = KeybindLoader.RegisterKeybind(Mod, "Switch Aerus Mode", "V");
            }
        }

        public override void Unload()
        {
            SwitchModeKeybind = null;
        }

        
    }

    // ── Celestial Aerus Sword ────────────────────────────────────────────────────
    public class CelestialAerus : ModItem
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/CelestialAerus";
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization
        }

        public override void SetDefaults()
        {
            Item.width = 120;
            Item.height = 120;
            Item.damage = 300;
            Item.useTime = 20;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(0, 50);
            Item.rare = ItemRarityID.Purple;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<CelestialFireball>();
            Item.shootSpeed = Item.useTime;
        }

        public override bool AltFunctionUse(Player player) => false;

        public override bool CanUseItem(Player player)
        {
            var modPlayer = player.GetModPlayer<AerusPlayer>();
            if (modPlayer.aerusMode == 1)
            {
                Item.noMelee = true;
                Item.noUseGraphic = true;
                Item.UseSound = SoundID.Item1;
            }
            else
            {
                Item.noMelee = false;
                Item.noUseGraphic = false;
                Item.UseSound = SoundID.Item60;
            }
            return true;
        }

        public override bool Shoot(
            Player player,
            EntitySource_ItemUse_WithAmmo source,
            Vector2 position,
            Vector2 velocity,
            int type,
            int damage,
            float knockBack
        )
        {
            var modPlayer = player.GetModPlayer<AerusPlayer>();

            if (modPlayer.aerusMode == 1)
            {
                Projectile.NewProjectile(
                    source, position, velocity,
                    ModContent.ProjectileType<ThrownCelestialAerus>(),
                    damage, knockBack, player.whoAmI
                );
            }
            else
            {
                // 🔒 Cooldown gate
                if (modPlayer.aerusFireballCooldown > 0)
                    return false;

                for (int i = 0; i < 6; i++)
                {
                    Vector2 spawn = new Vector2(
                        Main.MouseWorld.X + Main.rand.Next(-Main.screenWidth / 2, Main.screenWidth / 2),
                        Main.MouseWorld.Y - 400 - i * 80
                    );
                    Vector2 toCursor = Vector2.Normalize(Main.MouseWorld - spawn)
                        .RotatedByRandom(MathHelper.ToRadians(10f)) * 14f;
                    Projectile.NewProjectile(
                        source, spawn, toCursor,
                        type, damage, knockBack,
                        player.whoAmI, 0f, i * 12f
                    );
                }

                // ⏱️ Cooldown reset
                modPlayer.aerusFireballCooldown = 12;
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FragmentSolar, 20)
                .AddIngredient(ItemID.FragmentVortex, 20)
                .AddIngredient(ItemID.FragmentNebula, 20)
                .AddIngredient(ItemID.FragmentStardust, 20)
                .AddIngredient(ModContent.ItemType<AncientHatchet>())
                .AddIngredient(ItemID.Meowmere)
                .AddIngredient(ItemID.StarWrath)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            player.Heal(125);
            
            // Apply CelestialFlames debuff to target
            target.AddBuff(ModContent.BuffType<Buffs.Aerus.CelestialFlames>(), 300);
        }
    }

    // ── Homing Boomerang Projectile ────────────────────────────────────────────
    public class ThrownCelestialAerus : ModProjectile
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/ThrownCelestialAerus";
        
        public override void SetStaticDefaults()
            => DisplayName.SetDefault("Celestial Blade");

        public override void SetDefaults()
        {
            Projectile.width = 120;
            Projectile.height = 120;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.aiStyle = 0;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 160;
        }

        public override void AI()
        {
            Projectile.rotation += 0.4f;
            Lighting.AddLight(Projectile.Center,
                Main.DiscoR / 70f, Main.DiscoG / 70f, Main.DiscoB / 70f);
            float maxDetect = 500f, homingSpeed = 20f;
            NPC target = null;
            float minDist = maxDetect;
            foreach (NPC npc in Main.npc)
                if (npc.CanBeChasedBy(this))
                {
                    float dist = Vector2.Distance(Projectile.Center, npc.Center);
                    if (dist < minDist) { minDist = dist; target = npc; }
                }
            if (target != null)
            {
                Vector2 to = target.Center - Projectile.Center;
                Projectile.velocity = Vector2.Lerp(
                    Projectile.velocity,
                    Vector2.Normalize(to) * homingSpeed,
                    0.15f);
            }
            else
            {
                var player = Main.player[Projectile.owner];
                Vector2 toP = player.Center - Projectile.Center;
                if (Projectile.timeLeft < 300 || toP.Length() > 800f)
                {
                    Projectile.velocity = Vector2.Lerp(
                        Projectile.velocity,
                        Vector2.Normalize(toP) * 18f,
                        0.2f);
                    if (toP.Length() < 16f) Projectile.Kill();
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
            => Explode();
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
            => Explode();

        private void Explode()
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
            for (int j = 0; j < 40; j++)
            {
                var d = Dust.NewDustDirect(Projectile.Center, 1, 1, DustID.Smoke);
                d.velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi)
                    * Main.rand.NextFloat(5f, 12f);
                d.scale = Main.rand.NextFloat(1.2f, 2f);
                d.noGravity = false;
            }
            for (int j = 0; j < 24; j++)
            {
                var d = Dust.NewDustDirect(Projectile.Center, 1, 1, DustID.RainbowTorch);
                d.velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi)
                    * Main.rand.NextFloat(4f, 10f);
                d.scale = 1.6f;
                d.noGravity = true;
                d.fadeIn = 2f;
                d.alpha = 80;
            }
        }

        public override Color? GetAlpha(Color lightColor)
            => new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
    }

    // ── Player Keybind & Boomerang Logic ───────────────────────────────────────
    public class AerusPlayer : ModPlayer
    {
        public int aerusMode = 0;
        private int reuseTimer;
        public int aerusFireballCooldown;
        public int arkCooldown; // CONFIRM THIS LINE EXISTS
        public int celestialCooldown;
        public int arkCooldown2; // ADD THIS LINE

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (CelestialAerusMod.SwitchModeKeybind.JustPressed)
            {
                aerusMode = (aerusMode + 1) % 2;
                string mode = aerusMode == 1 ? "Boomerang" : "Fireball";
                Main.NewText($"Aerus Mode: {mode}", Color.LightGreen);
            }

            var item = Player.HeldItem;
            if (item.type == ModContent.ItemType<CelestialAerus>() &&
                aerusMode == 1 &&
                triggersSet.MouseLeft)
            {
                if (reuseTimer <= 0)
                {
                    Player.controlUseItem = true;
                    Player.releaseUseItem = false;
                    reuseTimer = item.useTime;
                }
            }
        }

        public override void PostUpdate()
        {
            if (reuseTimer > 0) reuseTimer--;
            if (aerusFireballCooldown > 0)
                aerusFireballCooldown--;
            if (celestialCooldown > 0)
                celestialCooldown--;
            if (arkCooldown > 0)
                arkCooldown--;
        }

        public override void ResetEffects()
        {
            if (celestialCooldown > 0)
                celestialCooldown--;
            if (arkCooldown > 0)
                arkCooldown--;
        }
    }

    // ── New Celestial Yoyo Item ────────────────────────────────────────────────
    public class ThreadOfTheEmpyrean : ModItem
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/ThreadOfTheEmpyrean";
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization

            // This makes the yoyo have a counterweight
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shoot = ModContent.ProjectileType<ThreadOfTheEmpyreanProjectile>();
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.channel = true;
            Item.damage = 1200;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Melee;
            Item.value = Item.sellPrice(0, 35);
            Item.rare = ItemRarityID.Red;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FragmentSolar, 12)
                .AddIngredient(ItemID.FragmentVortex, 12)
                .AddIngredient(ItemID.FragmentNebula, 12)
                .AddIngredient(ItemID.FragmentStardust, 12)
                .AddIngredient(ItemID.Terrarian)
                .AddIngredient(ItemID.LunarBar, 40)
                .AddIngredient(ModContent.ItemType<AncientHatchet>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }

    // ── Thread of the Empyrean Projectile ─────────────────────────────────────
    public class ThreadOfTheEmpyreanProjectile : ModProjectile
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/ThreadOfTheEmpyreanProjectile";
        private int fireTimer;

        // Enhanced graphics system for the yoyo
        private List<Vector2> trailPositions = new List<Vector2>();
        private List<float> trailRotations = new List<float>();
        private List<float> trailScales = new List<float>();
        private List<Color> trailColors = new List<Color>();
        private List<float> trailTimes = new List<float>();

        private const int MaxTrailLength = 10; // Reduced from 30 for better performance
        private const float TrailUpdateDistance = 5f; // Increased from 3f to reduce updates
        private const float TrailFadeTime = 0.5f; // Increased from 0.6f for longer trails

        private Vector2 lastTrailPosition;
        private float trailTimer;

        public override void SetStaticDefaults()
        {
            // DisplayName is now set via localization or automatically from class name
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 99;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 999999;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 60;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 999f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 999f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 80f;

            // Initialize trail system
            lastTrailPosition = Projectile.Center;
        }

        public override void AI()
        {
            fireTimer++;
            if (fireTimer >= 15) // Increased from 10 for better performance
            {
                fireTimer = 0;
                Vector2 spawn = Projectile.Center;
                Vector2 dir = Vector2.Normalize(Main.MouseWorld - spawn) * 12f;
                int p = Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    spawn, dir,
                    ModContent.ProjectileType<CelestialFireball>(),
                    Projectile.damage / 2, 2f, Projectile.owner
                );
                Main.projectile[p].tileCollide = false;
                Main.projectile[p].timeLeft = 300;
                Main.projectile[p].usesLocalNPCImmunity = true;
                Main.projectile[p].localNPCHitCooldown = 40;
            }

            // Optimized lighting with reduced calculations
            float intensity = 0.8f + (float)Math.Sin(Main.time * 0.3f) * 0.4f;
            Lighting.AddLight(Projectile.Center,
                Main.DiscoR / 255f * intensity,
                Main.DiscoG / 255f * intensity,
                Main.DiscoB / 255f * intensity);

            // Update yoyo trail system
            UpdateYoyoTrail();
        }

        private void UpdateYoyoTrail()
        {
            trailTimer += 0.016f; // Approximate 60fps timing

            // Add new trail position if enough distance traveled
            if (Vector2.Distance(Projectile.Center, lastTrailPosition) >= TrailUpdateDistance)
            {
                trailPositions.Add(Projectile.Center);
                trailRotations.Add(Projectile.rotation);
                trailScales.Add(Projectile.scale);
                trailTimes.Add(trailTimer);

                // Simplified rainbow colors for better performance
                float timeOffset = (float)Main.time * 0.15f;

                Color baseColor;
                // Use simpler color cycling based on time and position
                float hue = ((float)Main.time * 0.08f + trailPositions.Count * 0.1f) % 1f;
                baseColor = ColorFromHSV(hue, 0.8f, 1f); // Reduced saturation for better performance

                // Simplified pulsing (removed complex sine calculations)
                float pulse = 0.8f + 0.4f * (float)Math.Sin(timeOffset);
                baseColor = new Color(
                    (int)Math.Min(255, baseColor.R * pulse),
                    (int)Math.Min(255, baseColor.G * pulse),
                    (int)Math.Min(255, baseColor.B * pulse),
                    255
                );

                trailColors.Add(baseColor);
                lastTrailPosition = Projectile.Center;
            }

            // Remove old trail segments
            while (trailPositions.Count > MaxTrailLength)
            {
                trailPositions.RemoveAt(0);
                trailRotations.RemoveAt(0);
                trailScales.RemoveAt(0);
                trailColors.RemoveAt(0);
                trailTimes.RemoveAt(0);
            }

            // Fade out old segments
            for (int i = 0; i < trailPositions.Count; i++)
            {
                float age = trailTimer - trailTimes[i];
                if (age > TrailFadeTime)
                {
                    float fadeProgress = (age - TrailFadeTime) / 0.15f; // Quick fade for yoyo
                    if (fadeProgress >= 1f)
                    {
                        trailPositions.RemoveAt(i);
                        trailRotations.RemoveAt(i);
                        trailScales.RemoveAt(i);
                        trailColors.RemoveAt(i);
                        trailTimes.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Color originalColor = trailColors[i];
                        trailColors[i] = new Color(
                            (int)(originalColor.R * (1f - fadeProgress)),
                            (int)(originalColor.G * (1f - fadeProgress)),
                            (int)(originalColor.B * (1f - fadeProgress)),
                            (int)(originalColor.A * (1f - fadeProgress))
                        );
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            player.Heal(175);
        }

        public override Color? GetAlpha(Color lightColor)
            => new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);

        public override bool PreDraw(ref Color lightColor)
        {
            // Apply the shader effect for the trail
            CelestialTrailEffect.BeginDrawTrail();
            
            // Draw the enhanced yoyo Exobeam trail system with shader
            DrawYoyoTrail(lightColor);
            
            // End the shader effect for the trail
            CelestialTrailEffect.EndDrawTrail();

            // Then draw the main yoyo projectile with enhanced effects
            Texture2D texture = ModContent.Request<Texture2D>("CelestialCalamityAerus/Aerus/ThreadOfTheEmpyreanProjectile").Value;
            Vector2 drawPosition = Projectile.Center - Main.screenPosition;

            // Simplified intensity calculation
            float intensity = 0.6f + (float)Math.Sin(Main.time * 0.2f) * 0.4f;

            // Simplified color cycling
            Color baseColor = new Color(
                (int)(255 * (0.5 + 0.5 * (float)Math.Sin(Main.time * 0.06f))),
                (int)(255 * (0.5 + 0.5 * (float)Math.Sin(Main.time * 0.06f + MathHelper.TwoPi / 3))),
                (int)(255 * (0.5 + 0.5 * (float)Math.Sin(Main.time * 0.06f + 2 * MathHelper.TwoPi / 3)))
            );

            // Switch to additive blending for glow effects
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Apply the fire shader for the glow effect
            CelestialFireTrailEffect.BeginDrawTrail();
            
            // Reduced to 4 layers for better performance with shader
            for (int i = 0; i < 4; i++)
            {
                // Simplified calculations
                float scale = 1.0f + (i * 0.25f * intensity);
                Vector2 offset = new Vector2(i * 2f * intensity, i * 2f * intensity);
                Color haloColor = baseColor * (1f - (i * 0.2f)) * intensity;
                Main.spriteBatch.Draw(texture, drawPosition + offset, null, haloColor, Projectile.rotation, texture.Size() / 2, scale, SpriteEffects.None, 0f);
            }
            
            // End the fire shader
            CelestialFireTrailEffect.EndDrawTrail();

            // Reset to default blending
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Draw the main projectile with the celestial trail shader
            CelestialTrailEffect.BeginDrawTrail();
            Main.spriteBatch.Draw(texture, drawPosition, null, new Color(baseColor.ToVector4() * lightColor.ToVector4()), Projectile.rotation, texture.Size() / 2, Projectile.scale, SpriteEffects.None, 0f);
            CelestialTrailEffect.EndDrawTrail();

            return false;
        }

        private void DrawYoyoTrail(Color lightColor)
        {
            if (trailPositions.Count < 2) return;

            // For now, use the basic trail system until shader issues are resolved
            DrawBasicYoyoTrail(lightColor);
        }

        private void DrawBasicYoyoTrail(Color lightColor)
        {
            // Use the celestial trail shader for the yoyo trail
            CelestialTrailEffect.BeginDrawTrail();
            
            // Draw the trail with multiple layers for a glowing effect
            for (int i = 0; i < trailPositions.Count - 1; i++)
            {
                float progress = i / (float)trailPositions.Count;
                float opacity = 0.6f * (1f - progress);
                float scale = Projectile.scale * (0.8f + 0.4f * (float)Math.Sin(Main.GlobalTimeWrappedHourly * 4f));
                
                // Get the texture for the trail segment
                Texture2D texture = ModContent.Request<Texture2D>("CelestialCalamityAerus/Aerus/ThreadOfTheEmpyreanProjectile").Value;
                
                // Draw the trail segment with the shader effect
                Main.spriteBatch.Draw(
                    texture,
                    trailPositions[i] - Main.screenPosition,
                    null,
                    trailColors[i] * opacity,
                    trailRotations[i],
                    texture.Size() / 2f,
                    trailScales[i] * scale,
                    SpriteEffects.None,
                    0f
                );
            }
            
            // End the shader effect
            CelestialTrailEffect.EndDrawTrail();
            for (int i = 0; i < trailPositions.Count - 1; i++)
            {
                if (i >= trailPositions.Count - 1) break;

                Vector2 startPos = trailPositions[i] - Main.screenPosition;
                Vector2 endPos = trailPositions[i + 1] - Main.screenPosition;

                if (!IsOnScreen(trailPositions[i]) && !IsOnScreen(trailPositions[i + 1]))
                    continue;

                float segmentLength = Vector2.Distance(trailPositions[i], trailPositions[i + 1]);
                float segmentWidth = MathHelper.Lerp(12f, 20f, (float)i / trailPositions.Count) * trailScales[i]; // Reduced width
                float segmentRotation = (float)Math.Atan2(endPos.Y - startPos.Y, endPos.X - startPos.X);

                // Reduced to 2 layers for better performance (was 4)
                for (int layer = 0; layer < 2; layer++)
                {
                    float layerAlpha = (2 - layer) / 2f * 0.8f; // Simplified alpha calculation
                    Color layerColor = trailColors[i] * layerAlpha;

                    // Simplified white core effect
                    if (layer == 0)
                        layerColor = Color.Lerp(layerColor, Color.White, 0.3f);

                    // Draw with additive blending for glow
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

                    // Create beam segments with smooth gradient
                    Texture2D pixel = ModContent.Request<Texture2D>("Terraria/Images/Extra_194").Value;

                    // Reduced steps for smoother performance (was Math.Max(3, (int)(segmentLength / 2f)))
                    int steps = Math.Max(2, (int)(segmentLength / 3f));
                    for (int step = 0; step < steps; step++)
                    {
                        float progress = (float)step / steps;
                        Vector2 segmentPos = Vector2.Lerp(startPos, endPos, progress);

                        // Simplified width calculation
                        float stepWidth = segmentWidth * (1f - progress * 0.1f);

                        // Draw optimized beam
                        Main.spriteBatch.Draw(pixel,
                            new Rectangle((int)segmentPos.X - (int)(stepWidth / 2), (int)segmentPos.Y - 3, (int)stepWidth, 6),
                            null, layerColor, segmentRotation, Vector2.Zero, SpriteEffects.None, 0f);
                    }

                    // Reset to default blending for next layer
                    Main.spriteBatch.End();
                    Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);
                }
            }
        }

        private void DrawYoyoTrailSegment(Vector2 start, Vector2 end, float width, float rotation, Color color)
        {
            Vector2 direction = end - start;
            Vector2 perpendicular = Vector2.Normalize(direction).RotatedBy(MathHelper.PiOver2) * width * 0.5f;

            Vector2 topLeft = start + perpendicular;
            Vector2 topRight = end + perpendicular;
            Vector2 bottomLeft = start - perpendicular;
            Vector2 bottomRight = end - perpendicular;

            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Terraria/Images/Extra_194").Value,
                new Rectangle((int)start.X, (int)start.Y, (int)direction.Length(), (int)width),
                null, color, rotation, new Vector2(0, width * 0.5f), SpriteEffects.None, 0f);
        }

        private bool IsOnScreen(Vector2 position)
        {
            return position.X > Main.screenPosition.X - 100 &&
                   position.X < Main.screenPosition.X + Main.screenWidth + 100 &&
                   position.Y > Main.screenPosition.Y - 100 &&
                   position.Y < Main.screenPosition.Y + Main.screenHeight + 100;
        }

        // Helper method to convert HSV to RGB color
        private Color ColorFromHSV(float hue, float saturation, float value)
        {
            // Ensure hue is in 0-1 range
            hue = hue % 1f;
            if (hue < 0) hue += 1f;

            int hi = (int)(hue * 6) % 6;
            float f = (hue * 6) - hi;
            float p = value * (1 - saturation);
            float q = value * (1 - f * saturation);
            float t = value * (1 - (1 - f) * saturation);

            float r, g, b;
            switch (hi)
            {
                case 0: r = value; g = t; b = p; break;
                case 1: r = q; g = value; b = p; break;
                case 2: r = p; g = value; b = t; break;
                case 3: r = p; g = q; b = value; break;
                case 4: r = t; g = p; b = value; break;
                case 5: r = value; g = p; b = q; break;
                default: r = value; g = t; b = p; break;
            }

            return new Color((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
    }

    // ── Player class for Ark of the Celestials ───────────────────────────────
    public class CelestialArkPlayer : ModPlayer
    {
        public bool summonFireballs = false;
        private int fireballTimer = 0;
        private const int FireballDelay = 10; // 1/6th second at 60 FPS
        private List<Projectile> activeFireballs = new List<Projectile>();
        public int arkCooldown;

        public override void ResetEffects()
        {
            if (Player.HeldItem.type != ModContent.ItemType<ArkOfTheCelestials>())
                summonFireballs = false;
        }

        public override void PostUpdate()
        {
            if (arkCooldown > 0)
                arkCooldown--;
            if (!summonFireballs || Player.dead || Player.HeldItem.type != ModContent.ItemType<ArkOfTheCelestials>())
            {
                activeFireballs.Clear();
                return;
            }

            // Update active fireballs list
            activeFireballs.RemoveAll(p => !p.active || p.type != ModContent.ProjectileType<CelestialFireball>());

            // Spawn new fireballs if needed (up to 6)
            if (activeFireballs.Count < 6 && Main.myPlayer == Player.whoAmI)
            {
                fireballTimer++;
                if (fireballTimer >= FireballDelay)
                {
                    fireballTimer = 0;
                    
                    // Calculate position in a circle around the player
                    float radius = 100f;
                    float angle = Main.rand.NextFloat(MathHelper.TwoPi);
                    Vector2 spawnPos = Player.Center + new Vector2(
                        radius * (float)Math.Cos(angle),
                        radius * (float)Math.Sin(angle)
                    );

                    // Create fireball
                    int p = Projectile.NewProjectile(
                        Player.GetSource_FromThis(),
                        spawnPos,
                        Vector2.Zero,
                        ModContent.ProjectileType<CelestialFireball>(),
                        Player.HeldItem.damage / 2,
                        Player.HeldItem.knockBack,
                        Player.whoAmI
                    );
                    
                    // Make fireball orbit the player
                    if (p < Main.maxProjectiles)
                    {
                        Main.projectile[p].ai[0] = angle; // Store angle for orbit
                        activeFireballs.Add(Main.projectile[p]);
                    }
                }
            }

            // Update fireball positions to orbit the player
            for (int i = 0; i < activeFireballs.Count; i++)
            {
                var proj = activeFireballs[i];
                if (proj.active && proj.type == ModContent.ProjectileType<CelestialFireball>())
                {
                    float radius = 100f;
                    float angle = proj.ai[0] + 0.02f; // Rotation speed
                    proj.ai[0] = angle % MathHelper.TwoPi; // Keep angle in 0-2π range
                    
                    Vector2 targetPos = Player.Center + new Vector2(
                        radius * (float)Math.Cos(angle),
                        radius * (float)Math.Sin(angle)
                    );
                    
                    // Smooth movement towards orbit position
                    proj.velocity = (targetPos - proj.Center) * 0.2f;
                    
                    // Make fireballs face the direction they're moving
                    if (proj.velocity != Vector2.Zero)
                        proj.rotation = proj.velocity.ToRotation() + MathHelper.PiOver2;
                }
            }
        }
    }

    public class ArkAnimationPlayer : ModPlayer
    {
        public int swingTimer = 0;

        public override void PostUpdate()
        {
            if (Player.HeldItem.type == ModContent.ItemType<ArkOfTheCelestials>() && Player.itemAnimation > 0)
            {
                swingTimer = Player.itemAnimation;
            }
            else if (swingTimer > 0)
            {
                swingTimer--;
            }

            // Add glow effect when swinging
            if (swingTimer > 0)
            {
                float intensity = (float)swingTimer / 20f;
                Lighting.AddLight(Player.Center, intensity * 0.5f, intensity * 0.5f, 0f); // Yellow glow

                // Spawn dust for visual effect
                for (int i = 0; i < 2; i++)
                {
                    Dust.NewDust(Player.Center + new Vector2(-10, -10), 20, 20, DustID.Torch, 0, 0, 0, Color.Yellow, 1.5f);
                }
            }
        }
    }

    public class SwordGlowPlayer : ModPlayer
    {
        // Commented out due to PlayerLayer API limitations in tModLoader 1.4.3
        // The glow effect is handled by swing animations in other ModPlayers
    }
}