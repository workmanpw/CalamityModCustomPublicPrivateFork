using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Pets;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.SupremeCalamitas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    [LegacyName("SCalBag", "SupremeCalamitasCoffer")]
    public class CalamitasCoffer : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.TreasureBags";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.BossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossBags;
        }

        public override bool CanRightClick() => true;

        public override Color? GetAlpha(Color lightColor) => Color.Lerp(lightColor, Color.White, 0.4f);

        public override void PostUpdate() => Item.TreasureBagLightAndDust();

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            return CalamityUtils.DrawTreasureBagInWorld(Item, spriteBatch, ref rotation, ref scale, whoAmI);
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // Money
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<SupremeCalamitas>()));

            // Materials
            itemLoot.Add(ModContent.ItemType<AshesofAnnihilation>(), 1, 30, 40);

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<Violence>(),
                ModContent.ItemType<Condemnation>(),
                ModContent.ItemType<Heresy>(),
                ModContent.ItemType<Vehemence>(),
                ModContent.ItemType<Perdition>(),
                ModContent.ItemType<Vigilance>(),
                ModContent.ItemType<Sacrifice>()
            }));

            // Equipment
            itemLoot.Add(ModContent.ItemType<Calamity>());
            itemLoot.AddRevBagAccessories();

            // Vanity
            var scalVanitySet = ItemDropRule.Common(ModContent.ItemType<SCalMask>(), 7);
            scalVanitySet.OnSuccess(ItemDropRule.Common(ModContent.ItemType<AshenHorns>()));
            scalVanitySet.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SCalRobes>()));
            scalVanitySet.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SCalBoots>()));
            itemLoot.Add(scalVanitySet);
            itemLoot.Add(ModContent.ItemType<BrimstoneJewel>());
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);
        }
    }
}
