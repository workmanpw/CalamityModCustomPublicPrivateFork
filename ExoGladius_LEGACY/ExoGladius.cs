using CalamityMod.Items.Materials;
using CalamityMod.Projectiles.Melee;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.Buffs.DamageOverTime;
using System.Collections.Generic;

namespace CalamityMod.ExoGladius_LEGACY
{
    public class ExoGladiusLegacy : ModItem
    {
        public const int OnHitIFrames = 3;
        
        public override string Texture => "CalamityMod/ExoGladius_LEGACY/ExoGladius";
        
        public override void SetStaticDefaults()
        {
            // This item's display name and tooltip
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tooltip = new TooltipLine(Mod, "ExoGladiusTooltip", "Do not underestimate the power of Exoblade's younger brother\n" +
                "Striking an enemy with the blade makes you immune for a short time and summons comets from the sky\n" +
                "Fires a Exo orb that summons sword beams on hit");
            tooltips.Add(tooltip);
        }

        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 56;
            Item.damage = 690;
            Item.knockBack = 9.9f;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<ExoGladProj>();
            Item.shootSpeed = 19f;
            Item.DamageType = DamageClass.Melee;
            Item.value = Item.buyPrice(gold: 60);
            Item.rare = ItemRarityID.Red;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Calculate direction to mouse cursor
            Vector2 mousePos = Main.MouseScreen;
            mousePos += Main.screenPosition;
            Vector2 direction = (mousePos - player.Center).SafeNormalize(Vector2.Zero);
            
            // Fire orb toward mouse cursor
            Projectile.NewProjectile(source, position, direction * Item.shootSpeed, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumBroadsword, 1)
                .AddIngredient(ItemID.BrokenHeroSword, 1)
                .AddIngredient(ItemID.HallowedBar, 10)
                .AddIngredient(ItemID.SoulofLight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(5))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Terra);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
            OnHitEffects(player);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(ModContent.BuffType<MiracleBlight>(), 300);
            OnHitEffects(player);
        }

        private void OnHitEffects(Player player)
        {
            CalamityUtils.GiveIFrames(player, OnHitIFrames, OnHitIFrames, false);

            if (player.whoAmI == Main.myPlayer)
            {
                int damage = player.GetWeaponDamage(Item);
                CalamityUtils.ProjectileRain(player.GetSource_ItemUse(Item), player.Center, 400f, 100f, 500f, 800f, 25f, ModContent.ProjectileType<ExoGladCometLegacy>(), damage, 15f, player.whoAmI);
            }
        }
    }
}
