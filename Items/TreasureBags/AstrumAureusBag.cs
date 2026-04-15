using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Armor.Vanity;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using CalamityModCustomPublicPrivateFork.Items.Mounts;
using CalamityModCustomPublicPrivateFork.Items.PermanentBoosters;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture.Paintings;
using CalamityModCustomPublicPrivateFork.Items.Potions;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Magic;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Melee;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Ranged;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Rogue;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.NPCs.AstrumAureus;
using CalamityModCustomPublicPrivateFork.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.TreasureBags
{
    [LegacyName("AstrageldonBag")]
    public class AstrumAureusBag : ModItem, ILocalizedModType
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
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<AstrumAureus>()));

            // Materials
            itemLoot.Add(ModContent.ItemType<AureusCell>(), 1, 12, 16);
            itemLoot.Add(ModContent.ItemType<StarblightSoot>(), 1, 30, 40);
            itemLoot.Add(ItemID.FallenStar, 1, 20, 30);

            // Weapons
            itemLoot.Add(DropHelper.CalamityStyle(DropHelper.BagWeaponDropRateFraction, new int[]
            {
                ModContent.ItemType<Nebulash>(),
                ModContent.ItemType<AuroraBlazer>(),
                ModContent.ItemType<AlulaAustralis>(),
                ModContent.ItemType<BorealisBomber>(),
                ModContent.ItemType<AuroradicalThrow>()
            }));
            itemLoot.Add(ModContent.ItemType<LeonidProgenitor>(), 10);

            // Equipment
            itemLoot.Add(ModContent.ItemType<SuspiciousLookingJellyBean>());
            itemLoot.Add(ModContent.ItemType<InterstellarStompers>());
            itemLoot.AddRevBagAccessories();

            // Vanity
            itemLoot.Add(ModContent.ItemType<AstrumAureusMask>(), 7);
            itemLoot.Add(ModContent.ItemType<ThankYouPainting>(), ThankYouPainting.DropInt);

            // Other
            itemLoot.AddIf((info) => CalamityWorld.revenge && !info.player.Calamity().adrenalineBoostTwo, ModContent.ItemType<StarlightFuelCell>());
        }
    }
}
