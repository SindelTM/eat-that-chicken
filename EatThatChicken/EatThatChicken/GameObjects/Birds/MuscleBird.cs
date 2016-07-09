using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleBird: Bird
    {
        private const int MusleBirdDefaultScore = 5;

        private const int MuscleBirdDefaultHealth = 4;

        public MuscleBird(Size bounds, Position position, int speed)
            : base(MuscleBirdDefaultHealth, MusleBirdDefaultScore, bounds, position, speed)
        {
            this.PointAffect = MusleBirdDefaultScore;
        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/muscle.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
