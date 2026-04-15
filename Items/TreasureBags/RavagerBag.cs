using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.PermanentBoosters;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.TreasureBags.MiscGrabBags;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.Ravager;
using CalamityModCustomPublicPrivateFork.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    public class RavagerBag : ModItem, ILocalizedModType
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
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<RavagerBody>()));

            // Materials (contained in Geodes to prevent overwhelming item floods)
            itemLoot.AddIf(() => !DownedBossSystem.downedProvidence, ModContent.ItemType<FleshyGeode>());
            itemLoot.AddIf(() => DownedBossSystem.downedProvidence, ModContent.ItemType<NecromanticGeode>());

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<UltimusCleaver>(),
                ModContent.ItemType<RealmRavager>(),
                ModContent.ItemType<Hematemesis>(),
                ModContent.ItemType<SpikecragStaff>(),
                ModContent.ItemType<CraniumSmasher>(),
            }));
            itemLoot.Add(ModContent.ItemType<Vesuvius>(), 10);
            itemLoot.Add(ModContent.ItemType<CorpusAvertor>(), 20);

            // Equipment
            itemLoot.Add(ModContent.ItemType<BloodPact>());
            itemLoot.Add(ModContent.ItemType<FleshTotem>(), 2);
            itemLoot.AddIf(() => DownedBossSystem.downedProvidence, ModContent.ItemType<BloodflareCore>());
            itemLoot.AddRevBagAccessories();
            itemLoot.AddIf((info) => CalamityWorld.revenge && !info.player.Calamity().rageBoostTwo, ModContent.ItemType<InfernalBlood>());

            // Vanity
            itemLoot.Add(ModContent.ItemType<RavagerMask>(), 7);
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);
        }
    }
}
