using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Prefixes.VanillaPrefixChanges.Stats
{
    public struct PrefixMovementSpeedStat(float movementSpeedBonus) : IVanillaPrefixStat
    {
        public float MovementSpeedBonus = movementSpeedBonus;

        public readonly void ApplyEffects(Player player)
        {
            player.moveSpeed += MovementSpeedBonus;
        }

        public readonly void ModifyTooltip(TooltipLine line)
        {
            line.Text += "\n" + VanillaPrefixChange.GetMoveSpeedString(MovementSpeedBonus);
        }
    }
}
