using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Placeables.Furniture;
using CalamityModCustomPublicPrivateFork.Items.Tools.SpawnBlocker;
using CalamityModCustomPublicPrivateFork.Items.Weapons.Summon;
using CalamityModCustomPublicPrivateFork.Tiles.Abyss;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Fishing.SulphurCatches
{
    [LegacyName("AbyssalCrate")]
    public class SulphurousCrate : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Fishing";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
            ItemID.Sets.IsFishingCrate[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SulphurousCrateTile>());
            Item.width = Item.height = 32;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
        }

        public override bool CanRightClick() => true;
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // 20-50 Blocks @ 100%; Individually 33.33%
            itemLoot.Add(new OneFromRulesRule(1, new IItemDropRule[3]
            {
                ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Placeables.Abyss.SulphurousSand>(), 1, 20, 50),
                ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Placeables.Abyss.SulphurousSandstone>(), 1, 20, 50),
                ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Placeables.Abyss.HardenedSulphurousSandstone>(), 1, 20, 50)
            }));

            // Rusty Chest Loot @ 100%; Individually 25%
            itemLoot.Add(new OneFromOptionsNotScaledWithLuckDropRule(1, 1,
                ModContent.ItemType<BrokenWaterFilter>(),
                ModContent.ItemType<EffigyOfDecay>(),
                ModContent.ItemType<RustyBeaconPrototype>(),
                ModContent.ItemType<ScionsCurio>()
            ));

            itemLoot.AddBiomeCrateLootRules(false);
        }
    }
}
