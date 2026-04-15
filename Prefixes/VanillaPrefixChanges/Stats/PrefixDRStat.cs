using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Prefixes.VanillaPrefixChanges.Stats
{
    public struct PrefixDRStat(float DRbonus) : IVanillaPrefixStat
    {
        public float DRBouns = DRbonus;

        public readonly void ApplyEffects(Player player)
        {
            player.endurance += DRBouns;
        }

        public readonly void ModifyTooltip(TooltipLine line)
        {
            line.Text += "\n" + VanillaPrefixChange.GetDamageReductionString(DRBouns);
        }
    }
}
