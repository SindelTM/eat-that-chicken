namespace EatThatChicken.Factories
{
    using EatThatChicken.Contracts;
    using EatThatChicken.GameObjects.Hunters;
    using EatThatChicken.Common.Structs;

    class HunterFactory : IGameObjectFactory<Hunter>
    {
        private const int HunterBoundsHeight = 190;
        private const int HunterBoundsWidth = 90;
                          
        private const int HunterSpeed = 10;

        public Hunter Create(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(HunterBoundsWidth, HunterBoundsHeight);

            return new Hunter(bounds, position, HunterSpeed);
        }
    }
}
