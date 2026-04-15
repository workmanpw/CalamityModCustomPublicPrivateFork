using CalamityModCustomPublicPrivateFork.CalPlayer;
using CalamityModCustomPublicPrivateFork.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.Summon
{
    public class AmphibiansGuitarBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            CalamityPlayer modPlayer = player.Calamity();

            if (player.ownedProjectileCounts[ModContent.ProjectileType<AmphibiansGuitarMinion>()] > 0)
                modPlayer.AmphibiansGuitarBool = true;

            if (!modPlayer.AmphibiansGuitarBool)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
                player.buffTime[buffIndex] = 18000;
        }
    }
}
