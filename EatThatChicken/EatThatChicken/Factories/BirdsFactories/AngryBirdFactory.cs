using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.Enumerations;
using EatThatChicken.GameObjects;
namespace EatThatChicken.Factories.BirdsFactories
{
    using EatThatChicken.GameObjects.Birds;

    public class AngryBirdFactory : IGameObjectFactory<AngryBird>
    {
        private const int AngryBirdBoundsWidth = 60;
        private const int AngryBirdBoundsHeight = 70;

        private const int AngryBirdSpeed = 6;

        public AngryBird Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(AngryBirdBoundsWidth, AngryBirdBoundsHeight);

            return new AngryBird(bounds, position, AngryBirdSpeed);
        }
    }
}