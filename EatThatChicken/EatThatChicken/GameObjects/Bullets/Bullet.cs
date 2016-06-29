using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EatThatChicken.GameObjects.Bullets
{
    using Enumerations;

    public class Bullet : GameObject
    {
        private const int defaultSpeed = 40;
        private const MoveType defaultTop = MoveType.Incremental;
        private const MoveType defaultLeft = MoveType.None;

        public Bullet(Size bounds, Position position)
            : base(bounds, position, new MoveAction(defaultLeft, defaultTop, defaultSpeed)) { }

        public override void Draw(Canvas playGroundCanvas)
        {
            var rect = new Border
            {
                Width = this.Bounds.Width,
                Height = this.Bounds.Height,
                Background = Brushes.White,
                CornerRadius = new CornerRadius(10, 10, 0, 0)
            };

            Canvas.SetLeft(rect, this.Position.Left);
            Canvas.SetTop(rect, this.Position.Top);
            playGroundCanvas.Children.Add(rect);
        }
    }
}