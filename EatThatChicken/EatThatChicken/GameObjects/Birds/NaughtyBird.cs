using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Enumerations;

    public class NaughtyBird : Bird
    {
        private const int NaughtyBirdDefaultHealth = 2;

        private const uint NaughtyBirdDefaultScore = 2;

        public NaughtyBird(Size bounds, Position position, int speed)
            : base(NaughtyBirdDefaultHealth, NaughtyBirdDefaultScore, bounds, position, speed) { }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/naughty.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
