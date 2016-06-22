using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    public class MuscleBirdFactory : IGameObjectFactory<Bird>
    {
        // TODO: see if width, height is enough
        private const int MuscleBirdBoundsWidth = 60;
        private const int MuscleBirdBoundsHeight = 70;

        public Bird Get(int left, int top)
        {
            return new MuscleBird()
            {
                Position = new Position(left, top),
                Bounds = new Size(MuscleBirdBoundsWidth, MuscleBirdBoundsHeight)
            };
        }
    }
}
