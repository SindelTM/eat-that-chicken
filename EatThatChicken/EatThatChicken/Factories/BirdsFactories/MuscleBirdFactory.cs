using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.Factories.BirdsFactories
{
    public class MuscleBirdFactory : IGameObjectFactory<MuscleBird>
    {
        // TODO: see if width, height is enough
        private const int MuscleBirdBoundsWidth = 60;
        private const int MuscleBirdBoundsHeight = 70;

        public MuscleBird Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(MuscleBirdBoundsWidth, MuscleBirdBoundsHeight);

            return new MuscleBird(bounds, position);
        }
    }
}