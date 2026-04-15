using CalamityModCustomPublicPrivateFork.Buffs.Pets;
using CalamityModCustomPublicPrivateFork.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Pets
{
    [LegacyName("IbarakiBox")]
    public class HermitsBoxofOneHundredMedicines : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Pets";
        public override void SetDefaults()
        {
            Item.DefaultToVanitypet(ModContent.ProjectileType<ThirdSage>(), ModContent.BuffType<ThirdSageBuff>());
            Item.UseSound = SoundID.Item3;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.LightRed;
            Item.Calamity().devItem = true;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}
