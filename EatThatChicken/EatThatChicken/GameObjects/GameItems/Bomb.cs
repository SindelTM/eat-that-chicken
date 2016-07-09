using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class Bomb : Item
    {
        private const int DefaultPointToTake = -50;

        public Bomb(int speed, Size bounds, Position position)
            : base(bounds, position, speed)
        {
            this.PointAffect = DefaultPointToTake;
        }


        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/bomb.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
