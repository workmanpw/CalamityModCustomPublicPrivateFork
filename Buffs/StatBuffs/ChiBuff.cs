using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Buffs.StatBuffs
{
    public class ChiBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.08f;
        }
    }
}
