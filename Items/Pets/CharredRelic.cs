using CalamityModCustomPublicPrivateFork.Buffs.Pets;
using CalamityModCustomPublicPrivateFork.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Items.Pets
{
    public class CharredRelic : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Items.Pets";
        public override void SetDefaults()
        {
            Item.DefaultToVanitypet(ModContent.ProjectileType<BrimlingPet>(), ModContent.BuffType<BrimlingBuff>());
            Item.UseSound = SoundID.NPCHit51;
            Item.value = Item.sellPrice(gold: 2);
            Item.rare = ItemRarityID.Pink;
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
