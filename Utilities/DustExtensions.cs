using System;
using Terraria;

namespace CalamityMod.Utilities
{
    public static class DustExtensions
    {
        [Obsolete("DO NOT USE. It is an unsafe fix to an even more unsafe vanilla method.")]
        public static Dust BetterCloneDust(this Dust dust)
        {
            return BetterCloneDustStatic(dust);
        }

        [Obsolete("DO NOT USE. It is an unsafe fix to an even more unsafe vanilla method.")]
        public static Dust BetterCloneDustStatic(Dust rf)
        {
            if (rf.dustIndex == Main.maxDustToDraw)
            {
                return new Dust();
            }

            int num = Dust.NewDust(rf.position, 0, 0, rf.type);
            if (!Main.dust.IndexInRange(num))
            {
                return new Dust();
            }

            Dust obj = Main.dust[num];
            obj.position = rf.position;
            obj.velocity = rf.velocity;
            obj.type = rf.type;
            obj.color = rf.color;
            obj.alpha = rf.alpha;
            obj.frame = rf.frame;
            obj.shader = rf.shader;
            obj.customData = rf.customData;
            return obj;
        }

        [Obsolete("DO NOT USE. It is an unsafe fix to an even more unsafe vanilla method.")]
        public static Dust BetterCloneDust(this Dust dust, int dustIndex)
        {
            return BetterCloneDustStatic(Main.dust[dustIndex]);
        }
    }
}
