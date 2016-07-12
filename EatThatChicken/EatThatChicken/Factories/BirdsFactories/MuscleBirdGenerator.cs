namespace EatThatChicken.Factories.BirdsFactories
{
    using Contracts;
    using Common.Structs;
    using GameObjects.Birds;

    public class MuscleBirdGenerator : IGameObjectFactory<MuscleBird>
    {
        private const int MuscleBirdBoundsWidth = 60;
        private const int MuscleBirdBoundsHeight = 70;

        private const int MuscleBirdSpeed = 6;

        public MuscleBird Create(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(MuscleBirdBoundsWidth, MuscleBirdBoundsHeight);

            return new MuscleBird(bounds, position, MuscleBirdSpeed);
        }
    }
}