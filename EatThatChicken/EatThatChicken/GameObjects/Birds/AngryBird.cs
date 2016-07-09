using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int AngryBirdDefaulScore = 3;

        private const int AngryBirdDefaultHealth = 3;

        public AngryBird(Size bounds, Position position, int speed)
            : base(AngryBirdDefaultHealth, AngryBirdDefaulScore, bounds, position, speed)
        {
            this.PointAffect = AngryBirdDefaulScore;
        }

        public override void Draw(Canvas playGroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/angry.png", this.Position, this.Bounds);
            playGroundCanvas.Children.Add(image);
        }
    }
}
