using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    public class NaughtyBirdFactory : IGameObjectFactory<Bird>
    {
        // TODO: see if width, height is enough
        private const int NaughtyBirdBoundsWidth = 60;
        private const int NaughtyBirdBoundsHeight = 70;

        public Bird Get(int left, int top)
        {
            return new NaughtyBird()
            {
                Position = new Position(left, top),
                Bounds = new Size(NaughtyBirdBoundsWidth, NaughtyBirdBoundsHeight)
            };
        }
    }
}
