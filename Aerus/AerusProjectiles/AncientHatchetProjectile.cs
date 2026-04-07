using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using System;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Renderers;

namespace CalamityMod.Aerus.AerusProjectiles
{
    public class AncientHatchetProjectile : ModProjectile
    {
        // No need to store the effect instance anymore
        private int homingDelay = 15; // 1/4 second delay (60 frames = 1 second)
        private int homingTimer = 0;
        private int localImmuneCooldown = 60; // 1 second i-frames
        private NPC lastHitNPC = null;
        private List<Vector2> afterimagePositions = new List<Vector2>(); // For larger afterimages
        private int afterimageTimer = 0; // To control afterimage frequency
        private float scaleMultiplier = 1f; // For larger growing effect

        public override void SetStaticDefaults()
        {
            // DisplayName handled by localization
        }

        public override string Texture => "CelestialCalamityAerus/Aerus/AncientHatchetProjectile";

        // Removed Load() as we don't need to load the effect instance anymore

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.PossessedHatchet);
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.scale = 0.7f;
            Projectile.aiStyle = 3; // Boomerang AI
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1; // Infinite pierces
            Projectile.timeLeft = 300;
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false; // Ignore tiles
            Projectile.light = 1f;
            Projectile.usesLocalNPCImmunity = true; // Enable local immunity for bouncing
            Projectile.localNPCHitCooldown = localImmuneCooldown; // 1 second i-frames
        }

        public override void AI()
        {
            // Handle larger afterimages: Store position every few frames
            afterimageTimer++;
            if (afterimageTimer >= 2) // Every 2 frames for longer trail
            {
                afterimagePositions.Add(Projectile.Center);
                if (afterimagePositions.Count > 15) // Limit to 15 for larger trail
                {
                    afterimagePositions.RemoveAt(0);
                }
                afterimageTimer = 0;
            }

            // Larger growing effect: Scale up more when homing
            if (homingTimer >= homingDelay)
            {
                scaleMultiplier = Math.Min(scaleMultiplier + 0.03f, 2.0f); // Grow to 2x scale for larger effect
            }
            else
            {
                scaleMultiplier = Math.Max(scaleMultiplier - 0.02f, 1f); // Shrink back
            }

            // Only home after the delay
            if (homingTimer < homingDelay)
            {
                homingTimer++;
            }
            else
            {
                // Find a new target that we haven't hit recently
                NPC target = null;
                float minDistance = 1000f;
                foreach (NPC npc in Main.npc)
                {
                    if (npc.CanBeChasedBy(Projectile))
                    {
                        float distance = Vector2.Distance(Projectile.Center, npc.Center);
                        if (distance < minDistance && npc != lastHitNPC)
                        {
                            minDistance = distance;
                            target = npc;
                        }
                    }
                }

                if (target != null)
                {
                    Vector2 direction = target.Center - Projectile.Center;
                    direction.Normalize();
                    Projectile.velocity = direction * 22f; // Adjust speed as needed
                }
            }
            
            // Call base AI for boomerang behavior
            base.AI();
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // DRAW FIRE TRAIL FIRST
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);

            // Create fire trail from projectile positions
            List<Vector2> trailPositions = new List<Vector2>();
            for (int i = 0; i < Math.Min(Projectile.oldPos.Length, 15); i++)
            {
                if (Projectile.oldPos[i] != Vector2.Zero)
                {
                    trailPositions.Add(Projectile.oldPos[i] + Projectile.Size / 2f);
                }
            }
            trailPositions.Add(Projectile.Center);

            if (trailPositions.Count > 1)
            {
                // Draw fire trail segments
                for (int i = 0; i < trailPositions.Count - 1; i++)
                {
                    float progress = (float)i / trailPositions.Count;
                    float opacity = (1f - progress) * 0.7f;
                    Vector2 start = trailPositions[i];
                    Vector2 end = trailPositions[i + 1];
                    float distance = Vector2.Distance(start, end);

                    // Draw multiple fire particles along the trail
                    for (float j = 0; j < distance; j += 4f)
                    {
                        Vector2 pos = Vector2.Lerp(start, end, j / distance);
                        float size = (1f - progress) * 8f * Projectile.scale;

                        // Draw fire glow
                        Texture2D starTexture = TextureAssets.Extra[ExtrasID.SharpTears].Value; // Star texture for fire effect
                        Color fireColor = Color.Lerp(Color.Red, Color.Orange, progress) * opacity;
                        Main.spriteBatch.Draw(starTexture, pos - Main.screenPosition, null, fireColor, Main.GameUpdateCount * 0.1f + j * 0.1f, starTexture.Size() / 2f, size / starTexture.Width, SpriteEffects.None, 0f);
                    }
                }
            }

            // Reset to normal rendering
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullNone, null, Main.GameViewMatrix.TransformationMatrix);
            
            // Get the texture for the projectile
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
            
            // Draw the main projectile with a pulsing effect
            float mainScale = Projectile.scale * (0.9f + 0.1f * (float)Math.Sin(Main.GlobalTimeWrappedHourly * 4f));
            // Calculate draw position and origin
            Vector2 drawPosition = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
            Vector2 origin = texture.Size() / 2f;
            float intensity = 0.8f; // Default intensity value
            
            // Draw the main projectile with reduced opacity
            Main.spriteBatch.Draw(
                texture,
                drawPosition,
                null,
                Color.White * 0.9f,
                Projectile.rotation,
                origin,
                Projectile.scale,
                SpriteEffects.None,
                0f
            );
            
            // Switch to additive blending for larger glow/halo
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Larger enhanced halo effect: More layers with bigger pulsing
            for (int i = 0; i < 7; i++) // More layers for bigger halo
            {
                float scale = 1f + (i * 0.4f * intensity) + (float)Math.Sin(Main.GameUpdateCount * 0.1f) * 0.2f; // Bigger pulsing
                Vector2 offset = new Vector2(i * 3f * intensity, i * 3f * intensity); // Larger offsets
                Color haloColor = Color.Orange * (1f - (i * 0.15f)) * intensity;
                Main.spriteBatch.Draw(texture, drawPosition + offset, null, haloColor, Projectile.rotation, origin, scale, SpriteEffects.None, 0f);
            }

            // Reset to default blending
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Draw the main projectile with larger growing effect
            Main.spriteBatch.Draw(texture, drawPosition, null, Color.White, Projectile.rotation, origin, Projectile.scale * scaleMultiplier, SpriteEffects.None, 0f);

            return false; // We handled the drawing
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Lifesteal effect - heal player for 50 HP per hit
            Player player = Main.player[Projectile.owner];
            int lifeStealAmount = 50;

            // Ensure the player's health does not exceed their max health
            if (player.statLife + lifeStealAmount > player.statLifeMax2)
            {
                lifeStealAmount = player.statLifeMax2 - player.statLife;
            }

            // Heal the player for the calculated life steal amount
            player.Heal(lifeStealAmount);
            player.HealEffect(lifeStealAmount); // Show the heal effect

            // Remember the last hit NPC for homing logic
            lastHitNPC = target;

            // Apply Daybroken debuff
            target.AddBuff(BuffID.Daybreak, 300); // 5 seconds

            // MageHammer-style explosion with orange particles
            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<Projectiles.Typeless.MageHammerBoom>(), (int)(Projectile.damage * 0.25), Projectile.knockBack, Projectile.owner, 0f, 0f);
            }
            
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            
            // Orange explosion particles (modified from Triactis)
            for (int i = 0; i < 40; i++)
            {
                int orangeDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 2f);
                Main.dust[orangeDust].velocity *= 3f;
                if (Main.rand.NextBool())
                {
                    Main.dust[orangeDust].scale = 0.5f;
                    Main.dust[orangeDust].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
                }
            }
            for (int j = 0; j < 70; j++)
            {
                int orangeDust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 3f);
                Main.dust[orangeDust2].noGravity = true;
                Main.dust[orangeDust2].velocity *= 5f;
                orangeDust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, 0f, 0f, 100, default, 2f);
                Main.dust[orangeDust2].velocity *= 2f;
            }
            
            // Additional orange light burst
            for (int k = 0; k < 20; k++)
            {
                int lightDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Flare, 0f, 0f, 150, default, 1.5f);
                Main.dust[lightDust].noGravity = true;
                Main.dust[lightDust].velocity *= 4f;
                Main.dust[lightDust].color = new Color(255, 150, 0, 100);
            }
        }
    }
}
