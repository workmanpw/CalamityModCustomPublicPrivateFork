using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CelestialCalamityAerus;

public class AncientHatchet : ModItem
{
    public override string Texture => "CelestialCalamityAerus/Aerus/AncientHatchet";
    public override void SetStaticDefaults()
    {
        // DisplayName and Tooltip are now set via localization
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.PossessedHatchet);
        Item.width = 32;
        Item.height = 32;
        Item.damage = 140;
        Item.rare = ItemRarityID.Pink;
        Item.value = Item.sellPrice(0, 5);
        Item.shoot = ModContent.ProjectileType<AncientHatchetProjectile>();
        Item.shootSpeed = 22f; // Increased speed for better feel with infinite throw
        Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.autoReuse = true;
        Item.useTime = 15; // Faster use time for rapid throwing
        Item.useAnimation = 15;
        Item.consumable = false; // Makes it infinite
        Item.maxStack = 1; // Can't stack infinite items
    }
    
    // Allow infinite hatchets to be thrown
    public override bool CanUseItem(Player player)
    {
        // No limit on number of hatchets
        return true;
    }
    
    // Make the hatchet return when hitting an enemy
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        // Apply CelestialFlames debuff to target
        target.AddBuff(ModContent.BuffType<Buffs.Aerus.CelestialFlames>(), 300);
        
        // This will make the hatchet return after hitting an enemy
        for (int i = 0; i < Main.maxProjectiles; i++)
        {
            Projectile proj = Main.projectile[i];
            if (proj.active && proj.owner == player.whoAmI && proj.type == Item.shoot)
            {
                proj.ai[0] = 1f; // Make the projectile return
                proj.netUpdate = true;
            }
        }
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.PossessedHatchet)
            .AddIngredient(ItemID.FragmentSolar, 5)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
}
