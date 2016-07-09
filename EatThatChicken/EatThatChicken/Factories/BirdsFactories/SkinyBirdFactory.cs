using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;
namespace EatThatChicken.Factories.BirdsFactories
{
    public class SkinyBirdFactory : IGameObjectFactory<SkinyBird>
    {
        private const int SkinyBirdBoundsWidth = 60;
        private const int SkinyBirdBoundsHeight = 70;

        private const int SkinyBirdSpeed = 6;

        public SkinyBird Create(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(SkinyBirdBoundsWidth, SkinyBirdBoundsHeight);

            return new SkinyBird(bounds, position, SkinyBirdSpeed);
        }
    }
}