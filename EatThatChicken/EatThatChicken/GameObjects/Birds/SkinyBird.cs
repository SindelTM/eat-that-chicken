namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Common.Structs;

    public class SkinyBird: Bird
    {
        private const int SkinnyBirdDefaultHealth = 1;

        private const int SkinnyBirdDefaultScore = 1;

        public SkinyBird(Size bounds, Position position, int speed)
            : base(SkinnyBirdDefaultHealth, SkinnyBirdDefaultScore, bounds, position, speed)
        {
        }
    }
}
