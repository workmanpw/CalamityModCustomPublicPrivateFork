using Microsoft.Xna.Framework;

namespace CalamityModCustomPublicPrivateFork.InverseKinematics
{
    public interface IInverseKinematicsUpdateRule
    {
        void Update(LimbCollection limbs, Vector2 destination);
    }
}
