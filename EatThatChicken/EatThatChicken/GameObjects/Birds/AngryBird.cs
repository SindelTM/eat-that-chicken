using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int defaultSpeed = 6;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        private const int AngryBirdDefaultHealth = 3; 

        public AngryBird(Size bounds, Position position)
            :base(AngryBirdDefaultHealth, bounds, position, moveaction) { }
    }
}
