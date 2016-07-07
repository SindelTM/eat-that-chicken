using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class ChickenLeg : Item
    {
        private const int ChickenLegDefaultScore = 4;

        public ChickenLeg(int speed, Size bounds, Position position)
            :base(ChickenLegDefaultScore, bounds, position, speed)
        {
            
        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/chicken-leg.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
