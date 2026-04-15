using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.PermanentBoosters;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.Crabulon;
using CalamityModCustomPublicPrivateFork.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    public class CrabulonBag : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.TreasureBags";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Cyan;
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
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<Crabulon>()));

            // Materials
            itemLoot.Add(ItemID.GlowingMushroom, 1, 25, 35);
            itemLoot.Add(ItemID.MushroomGrassSeeds, 1, 5, 10);

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<MycelialClaws>(),
                ModContent.ItemType<Fungicide>(),
                ModContent.ItemType<HyphaeRod>(),
                ModContent.ItemType<InfestedClawmerang>(),
                ModContent.ItemType<Mycoroot>(),
                ModContent.ItemType<PuffShroom>(),
            }));

            // Equipment
            itemLoot.Add(ModContent.ItemType<FungalClump>());
            itemLoot.AddRevBagAccessories();

            // Vanity
            itemLoot.Add(ModContent.ItemType<CrabulonMask>(), 7);
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);

            // Other
            itemLoot.AddIf((info) => CalamityWorld.revenge && !info.player.Calamity().rageBoostOne, ModContent.ItemType<MushroomPlasmaRoot>());
        }
    }
}
