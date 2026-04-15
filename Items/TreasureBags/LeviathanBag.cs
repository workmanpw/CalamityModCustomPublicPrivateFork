using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Monoliths;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.Leviathan;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    public class LeviathanBag : ModItem, ILocalizedModType
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
            Item.rare = ItemRarityID.Cyan;
            Item.expert = true;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossBags;
        }

        public override bool CanRightClick() => true;

        public override Color? GetAlpha(Color lightColor) => Color.Lerp(lightColor, Color.White, 0.4f);

        public override void PostUpdate()
        {
            CalamityUtils.ForceItemIntoWorld(Item);
            Item.TreasureBagLightAndDust();
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            return CalamityUtils.DrawTreasureBagInWorld(Item, spriteBatch, ref rotation, ref scale, whoAmI);
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // Money
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<Leviathan>()));

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<Greentide>(),
                ModContent.ItemType<Leviatitan>(),
                ModContent.ItemType<AnahitasArpeggio>(),
                ModContent.ItemType<Atlantis>(),
                ModContent.ItemType<GastricBelcherStaff>(),
                ModContent.ItemType<Whitewater>(),
                ModContent.ItemType<LeviathanTeeth>(),
            }));

            // Equipment
            itemLoot.Add(ModContent.ItemType<LeviathanAmbergris>());
            itemLoot.Add(ModContent.ItemType<PearlofEnthrallment>(), DropHelper.BagWeaponDropRateFraction);
            itemLoot.Add(ModContent.ItemType<TheCommunity>(), 10);
            itemLoot.AddRevBagAccessories();

            // Vanity
            itemLoot.Add(ModContent.ItemType<AnahitaMask>(), 7);
            itemLoot.Add(ModContent.ItemType<LeviathanMask>(), 7);
            itemLoot.Add(ModContent.ItemType<DeepSeaAnchor>(), 10);
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);
        }
    }
}
