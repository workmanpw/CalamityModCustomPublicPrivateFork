using System;
using System.Collections.Generic;
using CalamityMod.Aerus.AerusBuffs;
using CalamityMod.Aerus.AerusProjectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityMod.Aerus
{
	public class CelestialTempest : ModItem
	{

		public override string Texture => "CalamityMod/Aerus/CelestialTempest";

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Celestial Tempest");
		}

		public override void SetDefaults()
		{
			Item.width = 76;
			Item.height = 76;
			Item.damage = 3000;
			Item.DamageType = DamageClass.Melee;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.crit += 25;
			Item.knockBack = 9.5f;
			Item.UseSound = SoundID.Item60;
			Item.autoReuse = true;
			Item.maxStack = 1;
			Item.value = 30000000;
			Item.rare = -ItemRarityID.Purple; // Negative value to hide reforge name in menus
			Item.shoot = ModContent.ProjectileType<EonBeam>();
			Item.shootSpeed = 28f;
			Item.prefix = -1;
			Item.noUseGraphic = false;
			Item.channel = false;
		}

		public override bool CanReforge()
		{
			return true; // Allow CelestialTempest to be reforged
		}

		public override bool AltFunctionUse(Player player)
		{
			return true; // Enable right-click functionality
		}

		public override bool? UseItem(Player player)
		{
			// Calculate rotation and position based on swing direction
			float rotation = (player.itemRotation + (player.direction < 0 ? MathHelper.Pi : 0f)) * player.direction;
			Vector2 slashOffset = new Vector2(Item.width * 1.1f, 0).RotatedBy(rotation);
			
			// Create slash with larger scaling for CelestialTempest
			float scaleFactor = (Item.width + Item.height) / 60f; // Largest scale factor for CelestialTempest
			
			// Create simple visual effect for slash
			// Could add dust effects here if needed
			return null;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
	        // Add custom tooltip
	        list.Add(new TooltipLine(Mod, "Tooltip0", "Fires different projectiles based on your biome\nRight click to summon TempestGalaxia2 from screen edges\nHeals 75 life on hit\nApplies various debuffs to enemies on hit\n'A legendary weapon forged from the essence of the cosmos'"));
	    }
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			// Check if this is a right-click (alt function use)
			if (player.altFunctionUse == 2)
			{
				// Right-click: Summon TempestGalaxia2 projectiles from around the screen
				SpawnTempestGalaxia2FromScreenEdges(player, source, damage, knockback);
				return false;
			}
			
			// Left-click: Original behavior
	        switch (Main.rand.Next(4))
			{
		    	case 0: type = ModContent.ProjectileType<TempestEonBeam>(); break;
		    	case 1: type = ModContent.ProjectileType<TempestEonBeamV2>(); break;
		    	case 2: type = ModContent.ProjectileType<TempestEonBeamV3>(); break;
		    	case 3: type = ModContent.ProjectileType<TempestEonBeamV4>(); break;
			}
	        int projectile = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, Main.myPlayer);
	        Main.projectile[projectile].timeLeft = 160;
	        Main.projectile[projectile].tileCollide = false;
			float num72 = Main.rand.Next(22, 30);
			damage = Main.rand.Next(500, 621);
	    	Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
	    	float num78 = (float)Main.mouseX + Main.screenPosition.X + vector2.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y + vector2.Y;
			if (player.gravDir == -1f)
			{
				num79 = Main.screenPosition.Y + (float)Main.screenHeight + (float)Main.mouseY + vector2.Y;
			}
			float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
			float num81 = num80;
			if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
			{
				num78 = (float)player.direction;
				num79 = 0f;
				num80 = num72;
			}
			else
			{
				num80 = num72 / num80;
			}
	    	num78 *= num80;
			num79 *= num80;
			int num107 = 4;
			for (int num108 = 0; num108 < num107; num108++)
			{
				vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(-(float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y);
				vector2.X = (vector2.X + player.Center.X) / 2f;
				vector2.Y -= (float)(100 * num108);
				num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
				num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
				num80 = num72 / num80;
				num78 *= num80;
				num79 *= num80;
				float speedX4 = num78 + (float)Main.rand.Next(-360, 361) * 0.02f;
				float speedY5 = num79 + (float)Main.rand.Next(-360, 361) * 0.02f;

				// Back to original TempestGalaxia2 projectiles for spread shots
				int projectileFire = Projectile.NewProjectile(source, vector2.X, vector2.Y, speedX4, speedY5, ModContent.ProjectileType<TempestGalaxia2>(), damage, knockback, player.whoAmI, 0f, (float)Main.rand.Next(3));
				Main.projectile[projectileFire].timeLeft = 80;
			}
	    	return false;
		}
		
		private void SpawnTempestGalaxia2FromScreenEdges(Player player, EntitySource_ItemUse_WithAmmo source, int damage, float knockback)
		{
			// Get cursor position in world coordinates
			Vector2 cursorWorldPos = Main.MouseWorld;
			
			// Screen boundaries with some padding
			float screenLeft = Main.screenPosition.X - 200;
			float screenRight = Main.screenPosition.X + Main.screenWidth + 200;
			float screenTop = Main.screenPosition.Y - 200;
			float screenBottom = Main.screenPosition.Y + Main.screenHeight + 200;
			
			// Number of projectiles to spawn
			int projectileCount = 12;
			
			for (int i = 0; i < projectileCount; i++)
			{
				// Calculate spawn position around the screen edges
				float angle = (float)i / projectileCount * MathHelper.TwoPi;
				Vector2 spawnPos = Vector2.Zero;
				
				// Determine which edge to spawn from based on angle
				if (angle < MathHelper.PiOver2) // Top edge
				{
					float t = angle / MathHelper.PiOver2;
					spawnPos = new Vector2(screenLeft + t * (screenRight - screenLeft), screenTop);
				}
				else if (angle < (float)Math.PI) // Right edge
				{
					float t = (angle - MathHelper.PiOver2) / MathHelper.PiOver2;
					spawnPos = new Vector2(screenRight, screenTop + t * (screenBottom - screenTop));
				}
				else if (angle < 3f * MathHelper.PiOver2) // Bottom edge
				{
					float t = (angle - (float)Math.PI) / MathHelper.PiOver2;
					spawnPos = new Vector2(screenRight - t * (screenRight - screenLeft), screenBottom);
				}
				else // Left edge
				{
					float t = (angle - 3f * MathHelper.PiOver2) / MathHelper.PiOver2;
					spawnPos = new Vector2(screenLeft, screenBottom - t * (screenBottom - screenTop));
				}
				
				// Calculate velocity towards cursor with high speed
				Vector2 direction = cursorWorldPos - spawnPos;
				direction.Normalize();
				Vector2 velocity = direction * 25f; // High speed for zooming effect
				
				// Add some randomness for visual effect
				velocity += new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
				
				// Create the TempestGalaxia2 projectile
				int projectile = Projectile.NewProjectile(
					source,
					spawnPos,
					velocity,
					ModContent.ProjectileType<TempestGalaxia2>(),
					damage,
					knockback,
					player.whoAmI,
					0f,
					0f
				);
				
				// Configure projectile for right-click behavior
				Main.projectile[projectile].timeLeft = 300; // Longer lifetime
				Main.projectile[projectile].tileCollide = false;
				Main.projectile[projectile].alpha = 255; // Start invisible for fade-in effect
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Cosmosis>());
			recipe.AddIngredient(ModContent.ItemType<ArkOfTheCelestials>());
			recipe.AddIngredient(ModContent.ItemType<AndromedasWrath>());
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	
	    public override void MeleeEffects(Player player, Rectangle hitbox)
	    {
	        if (Main.rand.NextBool(5))
			{
				int num250 = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.RainbowTorch, (float)(player.direction * 2), 0f, 150, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1.3f);
				Main.dust[num250].velocity *= 0.2f;
				Main.dust[num250].noGravity = true;
			}
	    }
	    
	    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	    {
	    	// Heal 75 life per hit (consistent with other projectiles)
	    	player.Heal(75);

	    	// Apply CelestialFlames debuff to target
	    	target.AddBuff(ModContent.BuffType<CelestialFlames>(), 300);

	    	// Apply biome-specific buffs to player based on current location
	    	ApplyBiomeSpecificBuffs(player);

	    	// Apply universal enemy debuffs on every hit
	    	ApplyEnemyDebuffs(target);
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
            bool forest = !corrupt && !crimson && !hell && !holy && !nebula && !stardust && !solar && !vortex && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneBeach && !player.ZoneDesert && !player.ZoneDungeon && !player.ZoneGlowshroom && !player.ZoneSkyHeight;
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
	        else
	        {
	            // Fallback for unknown biomes
	            player.AddBuff(BuffID.Swiftness, 300); // Default movement buff
	        }
        }
		
		private void ApplyEnemyDebuffs(NPC target)
		{
	        // Apply universal enemy debuffs on every hit (10 total)
	        target.AddBuff(BuffID.Ichor, 600); // Reduces defense by 15-20
	        target.AddBuff(BuffID.CursedInferno, 600); // Cursed flames DoT
	        target.AddBuff(BuffID.Venom, 600); // Venom DoT (stronger poison)
	        target.AddBuff(BuffID.Weak, 600); // Reduces damage by 10%
	        target.AddBuff(ModContent.BuffType<CrushedDefense>(), 600); // Cuts enemy defense to 0.
	        target.AddBuff(BuffID.OnFire, 600); // Burning DoT
	        target.AddBuff(BuffID.Poisoned, 600); // Poison DoT
	        target.AddBuff(BuffID.Frostburn, 600); // Frostbite effect
	        target.AddBuff(BuffID.Daybreak, 600); // Daybroken debuff
	        target.AddBuff(BuffID.StardustMinion, 600); // Celled debuff (reduces defense)
		}
	}
}
