using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    public class AngryBirdFactory : IGameObjectFactory<Bird>
    {
        // TODO: see if width, height is enough
        private const int AngryBirdBoundsWidth = 60;
        private const int AngryBirdBoundsHeight = 70; 

        public Bird Get(int left, int top)
        {
            return new AngryBird()
            {
                Position = new Position(left, top),
                Bounds = new Size(AngryBirdBoundsWidth, AngryBirdBoundsHeight)
            };
        }
    }
}
