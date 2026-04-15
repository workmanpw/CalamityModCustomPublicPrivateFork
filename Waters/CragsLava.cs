using CalamityModCustomPublicPrivateFork.Buffs.DamageOverTime;
using CalamityModCustomPublicPrivateFork.Systems;
using Terraria;
using Terraria.ModLoader;
using CalamityModCustomPublicPrivateFork.Dusts.WaterSplash;
using CalamityModCustomPublicPrivateFork.Gores.WaterDroplet;

namespace CalamityModCustomPublicPrivateFork.Waters
{
    public class CragsLava : ModLavaStyle
    {
        public override string WaterfallTexture => "CalamityModCustomPublicPrivateFork/Waters/CragsLavaflow";

        public override int GetSplashDust() => ModContent.DustType<CragsLavaSplash>();

        public override int GetDropletGore() => ModContent.GoreType<CragsLavaDroplet>();

        public override bool IsLavaActive() => Main.LocalPlayer.Calamity().ZoneCalamity || Main.LocalPlayer.Calamity().BrimstoneLavaFountainCounter > 0;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 2.48f / 4;
            g = 1.05f / 4;
            b = 0.98f / 4;
        }

        public override void InflictDebuff(Player player, int onfireDuration)
        {
        }
    }
}
