using System.Collections.Generic;
using CalamityModCustomPublicPrivateFork.Pathfinding.Movements;

namespace CalamityModCustomPublicPrivateFork.Pathfinding
{
    /// <summary>
    /// Defines an interface for an object that can use pathfinding.
    /// </summary>
    public interface IPathfinder
    {
        /// <summary>
        /// A enumerable collection of <see cref="IMovement"/>s this pathfinder can use while pathfinding.
        /// </summary>
        IEnumerable<IMovement> Movements { get; }

        /// <summary>
        /// A method that defines behavior when the pathfinding is still being calculated.
        /// </summary>
        void AwaitingPathBehavior();
    }
}
