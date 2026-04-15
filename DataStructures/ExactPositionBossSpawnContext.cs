using Microsoft.Xna.Framework;

namespace CalamityModCustomPublicPrivateFork.DataStructures
{
    public class ExactPositionBossSpawnContext : BaseBossSpawnContext
    {
        public override Vector2 DetermineSpawnPosition(Vector2 relativePosition) => relativePosition;
    }
}
