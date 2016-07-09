using EatThatChicken.Common;

namespace EatThatChicken.GameObjects.GameItems
{
    using System.Windows.Controls;
    using Contracts;

    [Item]
    public class ChickenLeg : Item, IScorable
    {
        private const int ChickenLegDefaultScore = 4;

        public ChickenLeg(int speed, Size bounds, Position position)
            : base(bounds, position, speed)
        {
            this.PointAffect = ChickenLegDefaultScore;
        }

        public uint Score { get; }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/chicken-leg.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
