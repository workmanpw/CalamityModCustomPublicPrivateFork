using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace CelestialCalamityAerus
{
    public class TempestEonBeamV3 : ModProjectile
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/TempestEonBeamV3";
        // Trail system - same as Ancient Hatchet!
        private List<TrailSegment> trailSegments = new List<TrailSegment>();
        private const int MaxTrailLength = 20; // Shorter trail
        private int trailTimer = 0;
        private Vector2 spawnPosition; // Store spawn position safely
        
        public struct TrailSegment
        {
            public Vector2 Position;
            public float Rotation;
            public float Scale;
            public float Alpha;
            public Color Color;
            public int Age;
            public float FireIntensity;
        }

    	public override void SetStaticDefaults()
		{
			// Enable trail caching like Ancient Hatchet
            ProjectileID.Sets.TrailCacheLength[Type] = 50; // More afterimages
            ProjectileID.Sets.TrailingMode[Type] = 2;
		}
    	
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Beam;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 200;
            AIType = ProjectileID.EnchantedBeam;
            Projectile.usesLocalNPCImmunity = true; // Use built-in immunity system
            Projectile.localNPCHitCooldown = 8; // 8 frame immunity
        }

        public override void AI()
        {
            // Initialize spawn position on first frame
            if (spawnPosition == Vector2.Zero)
            {
                spawnPosition = Projectile.Center;
            }
            
            // Update trail (NO SPINNING for EonBeam!)
            UpdateTrail();
            
            // Update lighting with green glow
            Lighting.AddLight(Projectile.Center, 0.2f, 0.9f, 0.35f);

            // NO DUSTS - REMOVED!
            
            // HOMING BEHAVIOR LIKE GALAXIA2
            float num472 = Projectile.Center.X;
			float num473 = Projectile.Center.Y;
			float num474 = 1600f;
			bool flag17 = false;
			for (int num475 = 0; num475 < 200; num475++)
			{
				if (Main.npc[num475].CanBeChasedBy(Projectile, false))
				{
					float num476 = Main.npc[num475].position.X + (float)(Main.npc[num475].width / 2);
					float num477 = Main.npc[num475].position.Y + (float)(Main.npc[num475].height / 2);
					float num478 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num476) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num477);
					if (num478 < num474)
					{
						num474 = num478;
						num472 = num476;
						num473 = num477;
						flag17 = true;
					}
				}
			}
			if (flag17)
			{
				float num483 = 35f;
				Vector2 vector35 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
				float num484 = num472 - vector35.X;
				float num485 = num473 - vector35.Y;
				float num486 = (float)Math.Sqrt((double)(num484 * num484 + num485 * num485));
				num486 = num483 / num486;
				num484 *= num486;
				num485 *= num486;
				Projectile.velocity.X = (Projectile.velocity.X * 20f + num484) / 21f;
				Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num485) / 21f;
			}
        }
        
        public override bool PreDraw(ref Color lightColor)
        {
            // Draw the trail like Ancient Hatchet
            DrawFireTrail();
            
            // Draw the main projectile
            DrawMainProjectile();
            
            return false;
        }
        
        private void UpdateTrail()
        {
            // Add new trail segment every frame for maximum smoothness
            trailTimer++;
            if (trailTimer >= 1)
            {
                TrailSegment newSegment = new TrailSegment
                {
                    Position = Projectile.Center,
                    Rotation = Projectile.rotation,
                    Scale = Projectile.scale * 1.05f, // Normal scale for new segments
                    Alpha = 0.8f, // Lower initial alpha for better afterimage effect
                    Color = GetFireColor(trailTimer * 0.2f), // Faster color cycling for visual interest
                    Age = 0,
                    FireIntensity = 1f
                };

                trailSegments.Add(newSegment);
                
                // Limit trail length
                var segmentCount = trailSegments.Count;
                if (segmentCount > MaxTrailLength)
                {
                    trailSegments.RemoveAt(0);
                }
                
                trailTimer = 0;
            }

            // Age and update trail segments with ultra-smooth transitions
            var totalCount = trailSegments.Count;
            for (int i = totalCount - 1; i >= 0; i--)
            {
                TrailSegment segment = trailSegments[i];
                segment.Age++;
                
                // Calculate distance from current projectile position for scaling
                float distance = Vector2.Distance(Projectile.Center, segment.Position);
                float distanceScale = Math.Max(0.3f, 1f - (distance / 800f)); // Smaller as it gets farther from current position
                
                // Ultra-smooth shrink for maximum fluidity with distance scaling
                segment.Scale *= 0.994f * distanceScale;
                
                // Very smooth fade for better afterimage blending
                segment.Alpha = Math.Max(0f, 1f - (segment.Age / (float)MaxTrailLength * 0.6f));
                
                // Update color as it ages with smooth transition
                segment.Color = GetFireColor(segment.Age * 0.25f);
                
                trailSegments[i] = segment;
                
                // Remove dead segments
                if (segment.Alpha <= 0f || segment.Scale < 0.05f)
                {
                    trailSegments.RemoveAt(i);
                }
            }
        }
        
        private Color GetFireColor(float time)
        {
            // Rainbow color cycling
            float hue = (time * 0.15f + Main.GlobalTimeWrappedHourly * 0.6f) % 1f;
            return Main.hslToRgb(hue, 1f, 0.7f);
        }
        
        private void DrawFireTrail()
        {
            // Draw trail segments like Ancient Hatchet
            Texture2D tex = Terraria.ModLoader.ModContent.Request<Texture2D>(Texture).Value;
            if (tex == null || tex.IsDisposed)
                return;

            Vector2 origin = tex.Size() / 2f;
            
            // Switch to additive blending for fire effect
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Draw trail segments
            foreach (TrailSegment segment in trailSegments)
            {
                if (segment.Alpha > 0f)
                {
                    // Multi-layer fire effect
                    for (int layer = 0; layer < 3; layer++)
                    {
                        float layerScale = segment.Scale * (1f + layer * 0.3f);
                        Color layerColor = segment.Color * (segment.Alpha * (1f - layer * 0.3f));
                        
                        Main.spriteBatch.Draw(
                            tex,
                            segment.Position - Main.screenPosition,
                            null,
                            layerColor,
                            segment.Rotation,
                            origin,
                            layerScale,
                            SpriteEffects.None,
                            0f
                        );
                    }
                }
            }
            
            // Reset to default blending
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);
        }
        
        private void DrawMainProjectile()
        {
            // Draw the projectile with rainbow effect
            Texture2D texture = Terraria.ModLoader.ModContent.Request<Texture2D>(Texture).Value;
            if (texture == null) return;
            
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            
            Main.EntitySpriteDraw(
                texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                null,
                Color.Lerp(Color.White, Color.Lime, 0.5f) * 0.8f,
                Projectile.rotation,
                drawOrigin,
                Projectile.scale,
                SpriteEffects.None,
                0
            );
        }
        
        public override void OnKill(int timeLeft)
        {
            // Create a small explosion of green dust
            for (int i = 0; i < 20; i++)
            {
                float hue = 0.33f + Main.rand.NextFloat(-0.1f, 0.1f);
                Dust dust = Dust.NewDustPerfect(
                    Projectile.Center,
                    DustID.GreenFairy,
                    Main.rand.NextVector2Circular(5f, 5f),
                    0,
                    Main.hslToRgb(hue, 1f, 0.7f),
                    1.5f
                );
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Add green dust on hit
            for (int i = 0; i < 5; i++)
            {
                float hue = 0.33f + Main.rand.NextFloat(-0.05f, 0.05f);
                Dust dust = Dust.NewDustPerfect(
                    target.Center,
                    DustID.GreenFairy,
                    Main.rand.NextVector2Circular(3f, 3f),
                    0,
                    Main.hslToRgb(hue, 1f, 0.7f),
                    1.2f
                );
                dust.noGravity = true;
            }
            
            // Apply venom debuff
            target.AddBuff(BuffID.Venom, 180); // 3 seconds
            
            // Small heal on hit
            Player player = Main.player[Projectile.owner];
            player.Heal(50);
        }
    }
}