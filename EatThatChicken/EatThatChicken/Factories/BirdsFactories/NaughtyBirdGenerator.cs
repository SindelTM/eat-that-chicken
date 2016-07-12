namespace EatThatChicken.Factories.BirdsFactories
{
    using Contracts;
    using EatThatChicken.Common.Structs;
    using GameObjects.Birds;

    public class NaughtyBirdGenerator : IGameObjectFactory<NaughtyBird>
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