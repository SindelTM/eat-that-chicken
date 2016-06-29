using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.Factories.BirdsFactories
{
    public class NaughtyBirdFactory : IGameObjectFactory<NaughtyBird>
    {
        // TODO: see if width, height is enough
        private const int NaughtyBirdBoundsWidth = 60;
        private const int NaughtyBirdBoundsHeight = 70;

        public NaughtyBird Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(NaughtyBirdBoundsWidth, NaughtyBirdBoundsWidth);

            return new NaughtyBird(bounds, position);
        }
    }
}