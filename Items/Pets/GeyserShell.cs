using CalamityModCustomPublicPrivateFork.Buffs.Pets;
using CalamityModCustomPublicPrivateFork.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Pets
{
    public class GeyserShell : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Pets";

        public override void SetDefaults()
        {
            Item.DefaultToVanitypet(ModContent.ProjectileType<FlakPet>(), ModContent.BuffType<FlakHermitBuff>());
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Pink;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 15, true);
            }
        }
    }
}
