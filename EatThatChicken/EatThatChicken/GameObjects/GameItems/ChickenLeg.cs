namespace EatThatChicken.GameObjects.GameItems
{
    using EatThatChicken.Common;
    using EatThatChicken.Common.Structs;

    [Item]
    public class ChickenLeg : Item
    {
        private const int ChickenLegDefaultScore = 10;

        public ChickenLeg(int speed, Size bounds, Position position)
            : base(bounds, position, speed, ChickenLegDefaultScore)
        {
        }
    }
}
