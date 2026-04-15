using CalamityModCustomPublicPrivateFork.Buffs.DamageOverTime;
using CalamityModCustomPublicPrivateFork.Buffs.StatDebuffs;
using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Accessories
{
    public class Nucleogenesis : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Accessories";
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 10));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 52;
            Item.value = CalamityGlobalItem.RarityDarkBlueBuyPrice;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<CosmicPurple>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            CalamityPlayer modPlayer = player.Calamity();
            modPlayer.nucleogenesis = true;
            modPlayer.shadowMinions = true; //shadowflame
            modPlayer.holyMinions = true; //holy flames
            modPlayer.voltaicJelly = true; //static discharge
            modPlayer.starTaintedGenerator = true; //astral infection and irradiated
            player.GetKnockback<SummonDamageClass>() += 3f;
            player.GetDamage<SummonDamageClass>() += 0.15f;
            player.buffImmune[ModContent.BuffType<Shadowflame>()] = true;
            player.buffImmune[ModContent.BuffType<Irradiated>()] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe().
                AddIngredient<StarTaintedGenerator>().
                AddIngredient<StatisCurse>().
                AddIngredient<AscendantSpiritEssence>(4).
                AddTile<CosmicAnvil>().
                Register();
        }
    }
}
