using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.StatBuffs
{
    public class GraxBoost : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.Calamity().graxDefense = true;
        }
    }
}
