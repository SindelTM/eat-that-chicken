using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    class Heart : Item
    {
        private const int HeartDefaultScore = 6;

        public Heart(int speed, Size bounds, Position position)
            :base(HeartDefaultScore, bounds, position, speed)
        {

        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/heart.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
