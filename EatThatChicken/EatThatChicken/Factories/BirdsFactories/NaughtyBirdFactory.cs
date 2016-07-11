using EatThatChicken.Common;
using EatThatChicken.Common.Structs;

namespace EatThatChicken.Factories.BirdsFactories
{
    using Contracts;
    using GameObjects;
    using GameObjects.Birds;

    public class NaughtyBirdFactory : IGameObjectFactory<NaughtyBird>
    {
        private const int NaughtyBirdBoundsWidth = 60;
        private const int NaughtyBirdBoundsHeight = 70;

        private const int NaughtyBirdSpeed = 6;

        public NaughtyBird Create(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(NaughtyBirdBoundsWidth, NaughtyBirdBoundsWidth);

            return new NaughtyBird(bounds, position, NaughtyBirdSpeed);
        }
    }
}