using Microsoft.Xna.Framework;

namespace CalamityModCustomPublicPrivateFork.DataStructures
{
    public abstract class BaseBossSpawnContext
    {
        public abstract Vector2 DetermineSpawnPosition(Vector2 relativePosition);
    }
}
