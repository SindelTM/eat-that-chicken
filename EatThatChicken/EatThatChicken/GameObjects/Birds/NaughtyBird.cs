using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Enumerations;

    public class NaughtyBird : Bird
    {
        private const int defaultSpeed = 6;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        private const int NaughtyBirdDefaultHealth = 2;

        public NaughtyBird(Size bounds, Position position)
            : base(NaughtyBirdDefaultHealth, bounds, position, moveaction) { }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/naughty.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
