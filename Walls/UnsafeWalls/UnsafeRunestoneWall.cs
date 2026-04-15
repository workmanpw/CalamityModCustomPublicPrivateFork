using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CalamityModCustomPublicPrivateFork.Walls.UnsafeWalls
{
    public class UnsafeRunestoneWall : ModWall, IVisibleThroughWater
    {
        public override string Texture => "CalamityModCustomPublicPrivateFork/Walls/RunestoneWall";
        int IVisibleThroughWater.WaterMapEntry { get; set; }

        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;

            this.AddMapEntryWithWaterVisibility(new Color(122, 59, 48));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        public override bool Drop(int i, int j, ref int type)
        {
            return false;
        }
    }
}
