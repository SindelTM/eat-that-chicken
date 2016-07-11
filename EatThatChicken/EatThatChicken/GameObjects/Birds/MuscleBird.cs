namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Common.Structs;

    public class MuscleBird: Bird
    {
        private const int MusleBirdDefaultScore = 5;

        private const int MuscleBirdDefaultHealth = 4;

        public MuscleBird(Size bounds, Position position, int speed)
            : base(MuscleBirdDefaultHealth, MusleBirdDefaultScore, bounds, position, speed)
        {
        }
    }
}
