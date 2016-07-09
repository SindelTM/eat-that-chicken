using EatThatChicken.Common;

namespace EatThatChicken.GameObjects.GameItems
{
    using System.Windows.Controls;
    using Contracts;

    [Item]
    public class ChickenLeg : Item
    {
        private const int ChickenLegDefaultScore = 10;

        public ChickenLeg(int speed, Size bounds, Position position)
            : base(bounds, position, speed)
        {
            this.PointAffect = ChickenLegDefaultScore;
        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/chicken-leg.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
