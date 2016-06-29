using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleBird: Bird
    {
        private const int defaultSpeed = 6;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        private const int MuscleBirdDefaultHealth = 4;

        public MuscleBird(Size bounds, Position position)
            :base(MuscleBirdDefaultHealth, bounds, position, moveaction) { }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/muscle.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
