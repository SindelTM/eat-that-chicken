namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Common.Structs;

    public class AngryBird: Bird
    {
        private const int AngryBirdDefaulScore = 3;

        private const int AngryBirdDefaultHealth = 3;

        public AngryBird(Size bounds, Position position, int speed)
            : base(AngryBirdDefaultHealth, AngryBirdDefaulScore, bounds, position, speed)
        {
        }
    }
}
