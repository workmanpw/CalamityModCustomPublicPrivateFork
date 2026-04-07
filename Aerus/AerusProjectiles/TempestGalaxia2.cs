using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Aerus.AerusBuffs;

namespace CalamityMod.Aerus.AerusProjectiles
{
    public class TempestGalaxia2 : ModProjectile
    {
		public override string Texture => "CelestialCalamityAerus/Aerus/TempestGalaxia2";
        // Trail system - same as Ancient Hatchet!
        private List<TrailSegment> trailSegments = new List<TrailSegment>();
        private const int MaxTrailLength = 20; // Shorter trail
        private int trailTimer = 0;
        private Vector2 spawnPosition; // Store spawn position safely
        
        // Spinning system
        private float spinSpeed = 0.3f; // Spin like hatchet
        
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
    	
        // Use shared immunity system instead of individual tracking
        // private Dictionary<int, int> personalImmunityTracker = new Dictionary<int, int>();

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
            Projectile.penetrate = 2; // Default penetration
            Projectile.DamageType = DamageClass.Melee;
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
            
            // Fade in from invisible (alpha 255) to visible (alpha 0)
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 15; // Fade in over ~17 frames
                if (Projectile.alpha < 0)
                {
                    Projectile.alpha = 0; // Clamp to 0
                }
            }
            
            // Spin like the hatchet
            Projectile.rotation += spinSpeed;
            
            // Update trail
            UpdateTrail();
            
            // Rainbow glow effect
            float hue = (Main.GlobalTimeWrappedHourly * 0.6f) % 1f;
            Color rainbowColor = Main.hslToRgb(hue, 1f, 0.7f);
            Lighting.AddLight(Projectile.Center, rainbowColor.ToVector3() * 1.2f);

            // NO DUSTS - REMOVED!
            
            float num472 = Projectile.Center.X;
			float num473 = Projectile.Center.Y;
			float num474 = 1600f;
			bool flag17 = false;
			for (int num475 = 0; num475 < 200; num475++)
			{
				// Check if this projectile can target this NPC (individual immunity check)
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
				return;
			}
			return;
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
            // Rainbow color cycling like CelestialFireball
            return new Color(
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f + time))),
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f + MathHelper.TwoPi / 3 + time))),
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f + 2 * MathHelper.TwoPi / 3 + time)))
            );
        }
        
        private void DrawFireTrail()
        {
            // Draw trail segments like Ancient Hatchet
            Texture2D tex = TextureAssets.Projectile[Type].Value;
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
            // Get texture and draw position
            Texture2D tex = TextureAssets.Projectile[Type].Value;
            if (tex == null || tex.IsDisposed)
                return;

            Vector2 origin = tex.Size() / 2f;
            Vector2 drawPosition = Projectile.Center - Main.screenPosition;

            // Switch to additive blending for glow
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Rainbow glow effect like CelestialFireball
            float intensity = 0.8f + (float)Math.Sin(Main.time * 0.1f) * 0.4f;
            Color baseColor = new Color(
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f))),
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f + MathHelper.TwoPi / 3))),
                (int)(255 * (0.5 + 0.5 * Math.Sin(Main.time * 0.08f + 2 * MathHelper.TwoPi / 3)))
            );

            // Multiple glow layers for rainbow effect
            for (int i = 0; i < 6; i++)
            {
                float scale = 1.0f + (i * 0.3f * intensity);
                Vector2 offset = new Vector2(i * 2f * intensity, i * 2f * intensity);
                Color haloColor = baseColor * (1f - (i * 0.15f)) * intensity;
                
                Main.spriteBatch.Draw(
                    tex,
                    drawPosition + offset,
                    null,
                    haloColor,
                    Projectile.rotation,
                    origin,
                    Projectile.scale * scale,
                    SpriteEffects.None,
                    0f
                );
            }

            // Reset to default blending
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, null, null, Main.GameViewMatrix.TransformationMatrix);

            // Draw the main projectile
            Main.spriteBatch.Draw(
                tex,
                drawPosition,
                null,
                Color.White,
                Projectile.rotation,
                origin,
                Projectile.scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
        	Player player = Main.player[Projectile.owner];
        	player.Heal(75);

        	// Apply base damage buffs universally
        	player.AddBuff(BuffID.Battle, 600); // 10% damage
        	player.AddBuff(BuffID.WellFed, 600); // 5% damage
        	player.AddBuff(BuffID.Wrath, 600); // 10% damage
        	player.AddBuff(BuffID.Rage, 600); // 10% damage
        	player.AddBuff(BuffID.MagicPower, 600); // 20% magic damage
        	player.AddBuff(BuffID.Ironskin, 600); // 8 defense
        	player.AddBuff(BuffID.RapidHealing, 600); // OP life regeneration

        	// Apply biome-specific buffs based on current location
        	ApplyBiomeSpecificBuffs(player);

        	// Apply Celestial Flames debuff with max stacks (nothing is immune)
        	target.AddBuff(ModContent.BuffType<CelestialFlames>(), 600); // 10 seconds at 60 ticks/second

        	// Apply Crushed Defense debuff (reduces defense by 100&, no defense left)
        	target.AddBuff(ModContent.BuffType<CrushedDefense>(), 600); // 10 seconds at 60 seconds

        	// Spawn ONE biome-specific projectile on every enemy hit
        	SpawnBiomeProjectiles(player, target.Center, target);
        }

        private void SpawnBiomeProjectiles(Player player, Vector2 targetPosition, NPC target)
        {
	        // Biome-based projectile selection for additional projectiles
	        bool holy = player.ZoneHallow;
	        bool nebula = player.ZoneTowerNebula;
	        bool stardust = player.ZoneTowerStardust;
	        bool solar = player.ZoneTowerSolar;
	        bool vortex = player.ZoneTowerVortex;
	        bool hell = player.ZoneUnderworldHeight;
	        bool corrupt = player.ZoneCorrupt;
	        bool crimson = player.ZoneCrimson;
	        bool dungeon = player.ZoneDungeon;
	        bool space = player.ZoneSkyHeight;
	        bool forest = !corrupt && !crimson && !hell && !holy && !nebula && !stardust && !solar && !vortex && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneBeach && !player.ZoneDesert && !dungeon && !player.ZoneGlowshroom && !space;
	        bool mushroom = player.ZoneGlowshroom;
	        bool desert = player.ZoneDesert;
	        bool pumpkinMoon = Main.pumpkinMoon;
	        bool frostMoon = Main.snowMoon;
	        bool bloodMoon = Main.bloodMoon;

	        int projectileType = ProjectileID.Bullet; // Default fallback
	        int damage = 250; // Reduced damage for additional projectiles

	        if (solar)
	        {
	            projectileType = ProjectileID.Daybreak; // Daybreak projectile for Solar
	        }
	        else if (nebula)
	        {
	            projectileType = ProjectileID.NebulaBlaze1; // Nebula Blaze for Nebula
	        }
	        else if (vortex)
	        {
	            projectileType = ProjectileID.VortexBeaterRocket; // Vortex Rocket for Vortex
	        }
	        else if (stardust)
	        {
	            projectileType = ProjectileID.StardustCellMinionShot; // Stardust Cell Shot for Stardust
	        }
	        else if (holy)
	        {
	            projectileType = ProjectileID.RainbowRodBullet; // Rainbow Rod for Hallow
	        }
	        else if (hell)
	        {
	            projectileType = ProjectileID.Flamelash; // Flamelash for Hell
	        }
	        else if (corrupt)
	        {
	            projectileType = ProjectileID.TinyEater; // Tiny Eater for Corruption
	        }
	        else if (crimson)
	        {
	            projectileType = ProjectileID.VampireKnife; // Vampire Knife for Crimson
	        }
	        else if (forest)
	        {
	            projectileType = ProjectileID.TerrarianBeam; // Terrarian orb for Forest
	        }
	        else if (mushroom) // Mushroom biome
	        {
	            projectileType = 131; // Spinning mushroom projectile for Mushroom biome
	        }
	        else if (desert) // Desert biome
	        {
	            projectileType = ProjectileID.BlackBolt; // Onyx Blaster projectile for Desert
	        }
	        else if (player.ZoneBeach) // Ocean biome
	        {
	            projectileType = ProjectileID.FlaironBubble; // Homing Flairon bubbles for Ocean
	        }
	        else if (player.ZoneSnow) // Snow biome
	        {
	            projectileType = ProjectileID.FrostBoltSword; // Frost Bolt for Snow
	        }
	        else if (pumpkinMoon)
	        {
	            projectileType = ProjectileID.FlamingJack; // Flaming Jack for Pumpkin Moon
	        }
	        else if (frostMoon)
	        {
	            projectileType = ProjectileID.FrostBoltSword; // Frost Bolt for Frost Moon
	        }
	        else if (bloodMoon)
	        {
	            projectileType = ProjectileID.BloodArrow; // Blood Arrow for Blood Moon (vampiric projectile)
	        }
	        else if (dungeon)
	        {
	            projectileType = ProjectileID.ShadowBeamFriendly; // Shadow Beam for Dungeon
	        }
	        else if (space)
	        {
	            projectileType = ProjectileID.FallingStar; // Falling Star for Space
	        }

	        // Spawn exactly 1 biome-specific projectile
	        Vector2 velocity = new Vector2(Main.rand.NextFloat(-6f, 6f), Main.rand.NextFloat(-6f, 6f));
	        velocity.Normalize();
	        velocity *= Main.rand.NextFloat(8f, 14f);

	        int newProjectile = Projectile.NewProjectile(
	            Projectile.GetSource_OnHit(target),
	            targetPosition,
	            velocity,
	            projectileType,
	            damage,
	            2f,
	            Projectile.owner
	        );
	        
	        // Make the projectile ignore immunity frames
	        Main.projectile[newProjectile].usesLocalNPCImmunity = false;
	        Main.projectile[newProjectile].localNPCHitCooldown = 0;
        }

        private void ApplyBiomeSpecificBuffs(Player player)
        {
	        // Biome-based buff selection for additional effects
	        bool holy = player.ZoneHallow;
	        bool nebula = player.ZoneTowerNebula;
	        bool stardust = player.ZoneTowerStardust;
	        bool solar = player.ZoneTowerSolar;
	        bool vortex = player.ZoneTowerVortex;
	        bool hell = player.ZoneUnderworldHeight;
	        bool corrupt = player.ZoneCorrupt;
	        bool crimson = player.ZoneCrimson;
	        bool dungeon = player.ZoneDungeon;
	        bool space = player.ZoneSkyHeight;
	        bool forest = !corrupt && !crimson && !hell && !holy && !nebula && !stardust && !solar && !vortex && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneBeach && !player.ZoneDesert && !dungeon && !player.ZoneGlowshroom && !space;
	        bool mushroom = player.ZoneGlowshroom;
	        bool desert = player.ZoneDesert;
	        bool pumpkinMoon = Main.pumpkinMoon;
	        bool frostMoon = Main.snowMoon;
	        bool bloodMoon = Main.bloodMoon;

	        if (solar)
	        {
	            // Solar Tower: Fire, speed, and protection
	            player.AddBuff(BuffID.Inferno, 300); // Fire immunity
	            player.AddBuff(BuffID.Swiftness, 600); // Movement speed
	            player.AddBuff(BuffID.PaladinsShield, 600); // Holy protection
	        }
	        else if (nebula)
	        {
	            // Nebula Tower: Magic damage and mana
	            player.AddBuff(BuffID.NebulaUpDmg3, 600); // 60% magic damage
	            player.AddBuff(BuffID.NebulaUpLife3, 600); // Mana and life regen
	            player.AddBuff(BuffID.ManaRegeneration, 600); // Extra mana regen
	        }
	        else if (vortex)
	        {
	            // Vortex Tower: Defense and ranged
	            player.AddBuff(BuffID.Titan, 900); // 15% damage boost
	            player.AddBuff(BuffID.AmmoReservation, 600); // Defense and ammo
	            player.AddBuff(BuffID.Invisibility, 300); // Stealth effect
	        }
	        else if (stardust)
	        {
	            // Stardust Tower: Summoner and minions
	            player.AddBuff(BuffID.Summoning, 600); // +1 minion capacity
	            player.AddBuff(BuffID.Bewitched, 600); // +2 minion capacity
	            player.AddBuff(BuffID.RapidHealing, 900); // Enhanced healing
	        }
	        else if (holy)
	        {
	            // Hallow: Light and thorns (unique)
	            player.AddBuff(BuffID.Shine, 600); // Light effect
	            player.AddBuff(BuffID.Thorns, 600); // Return damage (ONLY here!)
	            player.AddBuff(BuffID.Endurance, 600); // Damage reduction
	        }
	        else if (hell)
	        {
	            // Underworld: Fire immunity and mining
	            player.AddBuff(BuffID.ObsidianSkin, 600); // Fire immunity
	            player.AddBuff(BuffID.Inferno, 300); // Fire aura
	            player.AddBuff(BuffID.Mining, 600); // Enhanced mining
	        }
	        else if (corrupt)
	        {
	            // Corruption: Shadow and detection
	            player.AddBuff(BuffID.Wrath, 900); // Damage boost
	            player.AddBuff(BuffID.Dangersense, 600); // Danger detection
	            player.AddBuff(BuffID.ShadowDodge, 600); // Dodge chance
	        }
	        else if (crimson)
	        {
	            // Crimson: Life steal and aggression
	            player.AddBuff(BuffID.Rage, 900); // Critical damage
	            player.AddBuff(BuffID.Battle, 900); // Enemy spawn boost
	            player.AddBuff(BuffID.Lifeforce, 600); // Heart pickup range
	        }
	        else if (desert)
	        {
	            // Desert: Sand movement and mining
	            player.AddBuff(BuffID.Swiftness, 600); // Movement speed
	            player.AddBuff(BuffID.Mining, 600); // Mining speed
	            player.AddBuff(BuffID.Spelunker, 600); // Treasure detection
	        }
	        else if (player.ZoneSnow)
	        {
	            // Snow: Cold protection and movement
	            player.AddBuff(BuffID.IceBarrier, 600); // Ice barrier
	            player.AddBuff(BuffID.Featherfall, 600); // Slow fall
	            player.AddBuff(BuffID.Warmth, 600); // Cold immunity
	        }
	        else if (player.ZoneJungle)
	        {
	            // Jungle: Nature and exploration
	            player.AddBuff(BuffID.BoneJavelin, 900); // Dryad's Blessing (unique nature buff)
	            player.AddBuff(BuffID.Spelunker, 600); // Treasure finding
	            player.AddBuff(BuffID.Regeneration, 600); // Health regen
	        }
	        else if (player.ZoneBeach)
	        {
	            // Ocean: Water abilities
	            player.AddBuff(BuffID.Gills, 600); // Water breathing
	            player.AddBuff(BuffID.Flipper, 600); // Swimming
	            player.AddBuff(BuffID.WaterWalking, 600); // Walk on water
	        }
	        else if (mushroom)
	        {
	            // Mushroom: Magic and mystery
	            player.AddBuff(BuffID.ManaRegeneration, 900); // Mana regen
	            player.AddBuff(BuffID.MagicPower, 900); // Magic damage
	            player.AddBuff(BuffID.Lucky, 600); // Luck boost
	        }
	        else if (forest)
	        {
	            // Forest: Natural and peaceful
	            player.AddBuff(BuffID.WellFed3, 900); // Enhanced food
	            player.AddBuff(BuffID.PeaceCandle, 600); // Enemy spawn reduction
	            player.AddBuff(BuffID.Regeneration, 600); // Health regen
	        }
	        else if (pumpkinMoon)
	        {
	            // Pumpkin Moon: Halloween theme
	            player.AddBuff(BuffID.Battle, 900); // Combat boost
	            player.AddBuff(BuffID.NightOwl, 600); // Night vision
	            player.AddBuff(BuffID.Lucky, 600); // Luck boost
	        }
	        else if (frostMoon)
	        {
	            // Frost Moon: Ice and magic
	            player.AddBuff(BuffID.Rage, 900); // Critical damage
	            player.AddBuff(BuffID.IceBarrier, 600); // Ice protection
	            player.AddBuff(BuffID.MagicPower, 600); // Magic damage
	        }
	        else if (bloodMoon)
	        {
	            // Blood Moon: Vampiric and aggressive
	            player.AddBuff(BuffID.Tipsy, 600); // Combat boost with penalty
	            player.AddBuff(BuffID.Battle, 600); // Enemy spawn boost
	            player.AddBuff(BuffID.RapidHealing, 900); // Enhanced healing
	        }
	        else if (dungeon)
	        {
	            // Dungeon: Shadow and mystery
	            player.AddBuff(BuffID.ShadowDodge, 600); // Dodge chance
	            player.AddBuff(BuffID.Dangersense, 600); // Danger detection
	            player.AddBuff(BuffID.MagicPower, 600); // Magic damage
	        }
	        else if (space)
	        {
	            // Space: Cosmic and stellar
	            player.AddBuff(BuffID.MagicPower, 900); // Magic damage
	            player.AddBuff(BuffID.ManaRegeneration, 900); // Mana regen
	            player.AddBuff(BuffID.Lucky, 600); // Luck boost
	        }
	        player.AddBuff(BuffID.RapidHealing, 900); // Enhanced life regeneration
        }
    }
}