using System.Collections.Generic;
using CalamityModCustomPublicPrivateFork.Items.Accessories;
using CalamityModCustomPublicPrivateFork.Items.Accessories.Vanity;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Systems.Collections
{
    public sealed class LegOverrideList : ModSystem
    {
        public static IList<int> List { get; private set; }

        public override void OnModLoad()
        {
            List =
            [
                EquipLoader.GetEquipSlot(ModContent.GetInstance<CalamityMod>(), nameof(ProfanedSoulCrystal), EquipType.Legs),
                EquipLoader.GetEquipSlot(ModContent.GetInstance<CalamityMod>(), nameof(AquaticHeart), EquipType.Legs),
                //CalamityModCustomPublicPrivateFork.Instance.GetEquipSlot(nameof(SirenLeg), EquipType.Legs), whate even was SirenLeg vs SirenLegAlt?
                EquipLoader.GetEquipSlot(ModContent.GetInstance<CalamityMod>(), nameof(Popo), EquipType.Legs)
            ];
        }

        public override void Unload() => List = null;

        public static bool Includes(int equipSlot) => List.Contains(equipSlot);
    }
}
