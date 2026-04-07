using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CalamityMod.Aerus.AerusBuffs
{
    public class AndromedasRage : ModBuff
    {
        public override string Texture => "CelestialCalamityAerus/Aerus/CelestialFireball"; // Use Celestial Fireball texture as icon

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true; // Buff doesn't save when exiting world
            Main.buffNoTimeDisplay[Type] = false; // Show time remaining
            // DisplayName and Description are handled by localization files in modern tModLoader
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Grant 50% damage increase for 5 seconds (300 ticks)
            player.GetDamage(DamageClass.Generic) += 0.5f;

            // Visual effect - golden dust particles
            if (Main.rand.NextBool(8)) // 12.5% chance per tick
            {
                int dustIndex = Dust.NewDust(
                    player.position,
                    player.width,
                    player.height,
                    DustID.GoldFlame,
                    Main.rand.NextFloat(-1f, 1f),
                    Main.rand.NextFloat(-1f, 1f),
                    100,
                    new Color(255, 215, 0), // Gold color
                    1.2f
                );
                Main.dust[dustIndex].noGravity = true;
            }
        }
    }
}
