using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Pets;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.BrimstoneElemental;
using CalamityModCustomPublicPrivateFork.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    [LegacyName("BrimstoneWaifuBag")]
    public class BrimstoneElementalBag : ModItem, ILocalizedModType
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
            Item.expert = true;
            Item.rare = ItemRarityID.Cyan;
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
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<BrimstoneElemental>()));

            // Materials
            itemLoot.Add(ModContent.ItemType<EssenceofHavoc>(), 1, 10, 12);

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<Brimlance>(),
                ModContent.ItemType<SeethingDischarge>(),
                ModContent.ItemType<DormantBrimseeker>(),
                ModContent.ItemType<Hellborn>()
            }));

            // Equipment
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<RoseStone>(),
            }));
            itemLoot.Add(ModContent.ItemType<FlameLickedShell>());
            itemLoot.AddRevBagAccessories();

            // Vanity
            itemLoot.Add(ModContent.ItemType<BrimstoneElementalMask>(), 7);
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);
            itemLoot.AddIf(() => CalamityWorld.revenge, ModContent.ItemType<CharredRelic>());
        }
    }
}
