using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int defaultSpeed = 1;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        private const int AngryBirdDefaultHealth = 3; 

        public AngryBird(Size bounds, Position position)
            :base(AngryBirdDefaultHealth, bounds, position, moveaction) { }

        public override void Draw(Canvas playGroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/angry.png", this.Position, this.Bounds);
            playGroundCanvas.Children.Add(image);
        }
    }
}
