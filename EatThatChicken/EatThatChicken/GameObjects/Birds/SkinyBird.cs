using EatThatChicken.Common;

namespace EatThatChicken.GameObjects.Birds
{
    using System.Windows.Controls;

    public class SkinyBird: Bird
    {
        private const int SkinnyBirdDefaultHealth = 1;

        private const int SkinnyBirdDefaultScore = 1;

        public SkinyBird(Size bounds, Position position, int speed)
            : base(SkinnyBirdDefaultHealth, SkinnyBirdDefaultScore, bounds, position, speed)
        {
            this.PointAffect = SkinnyBirdDefaultScore;
        }
    }
}
