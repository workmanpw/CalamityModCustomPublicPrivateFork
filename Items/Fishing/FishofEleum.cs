using Terraria;
using Terraria.Localization;

namespace CalamityModCustomPublicPrivateFork.Items.Fishing
{
    public class FishofEleum : BaseQuestFish
    {
        public override bool QuestCondition => Main.hardMode;
        public override LocalizedText Location => CalamityUtils.GetText("Items.Fishing.CaughtInSnow");
    }
}
