using Microsoft.Xna.Framework;

namespace CalamityModCustomPublicPrivateFork.Gores.WaterDroplet
{
    public class CragsLavaDroplet : LiquidDropletGore
    {
        public override bool lavaDroplet => true;

        public override Vector3 lavaColor => new Vector3(2.5f, 1.1f, 0.1f);
    }
}
