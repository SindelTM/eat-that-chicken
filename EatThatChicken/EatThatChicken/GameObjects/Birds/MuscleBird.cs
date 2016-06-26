using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleBird: Bird
    {
        private const int defaultSpeed = 20;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private const int MuscleBirdDefaultHealth = 5;

        public MuscleBird()
            :base(MuscleBirdDefaultHealth) { }
    }
}
