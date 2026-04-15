using CalamityModCustomPublicPrivateFork.Events;
using CalamityModCustomPublicPrivateFork.Rarities;
using CalamityModCustomPublicPrivateFork.World;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Tools
{
    public class SulphurousSeaWorldSideChanger : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Tools";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 0;
        }

        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 46;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.rare = ModContent.RarityType<HotPink>();
            Item.value = 0;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item111;
        }

        public override bool? UseItem(Player player)
        {
            CalamityNetcode.SyncWorld();
            string key = "Mods.CalamityModCustomPublicPrivateFork.Misc.SulphurSwitchLeft";
            if (Abyss.AtLeftSideOfWorld)
            {
                Abyss.AtLeftSideOfWorld = false;
                key = "Mods.CalamityModCustomPublicPrivateFork.Misc.SulphurSwitchRight";
            }
            else
            {
                Abyss.AtLeftSideOfWorld = true;
            }
            CalamityUtils.BroadcastLocalizedText(key, AcidRainEvent.TextColor);
            return true;
        }
    }
}
