namespace EatThatChicken.Factories.BirdsFactories
{
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Contracts;
    using EatThatChicken.GameObjects.Birds;

    public class AngryBirdGenerator : IGameObjectFactory<AngryBird>
    {
        private const int AngryBirdBoundsWidth = 60;
        private const int AngryBirdBoundsHeight = 70;

        private const int AngryBirdSpeed = 6;

        public AngryBird Create(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(AngryBirdBoundsWidth, AngryBirdBoundsHeight);

            return new AngryBird(bounds, position, AngryBirdSpeed);
        }
    }
}