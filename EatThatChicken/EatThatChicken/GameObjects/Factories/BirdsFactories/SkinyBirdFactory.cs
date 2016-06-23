using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    public class SkinyBirdFactory : IGameObjectFactory<SkinyBird>
    {
        // TODO: see if width, height is enough
        private const int SkinyBirdBoundsWidth = 60;
        private const int SkinyBirdBoundsHeight = 70;

        public SkinyBird Get(int left, int top)
        {
            return new SkinyBird()
            {
                Position = new Position(left, top),
                Bounds = new Size(SkinyBirdBoundsWidth, SkinyBirdBoundsHeight)
            };
        }
    }
}
