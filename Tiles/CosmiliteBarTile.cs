using CalamityModCustomPublicPrivateFork.Dusts;
using CalamityModCustomPublicPrivateFork.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Tiles
{
    public class CosmiliteBarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            this.SetUpBar(ModContent.ItemType<CosmiliteBar>(), new Color(229, 141, 246));
            DustType = ModContent.DustType<CosmiliteBarDust>();
        }

        public override bool CreateDust(int i, int j, ref int type)
        {
            type = ModContent.DustType<CosmiliteBarDust>();
            return true;
        }
    }
}
