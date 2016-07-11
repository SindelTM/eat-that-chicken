using EatThatChicken.Common.Structs;

namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Common;

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
