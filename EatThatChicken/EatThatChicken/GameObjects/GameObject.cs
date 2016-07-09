using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EatThatChicken.Common;

namespace EatThatChicken.GameObjects
{
    using Contracts;

    public abstract class GameObject : IGameObject
    {
        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position, MoveAction moveAction)
            : this()
        {
            this.Bounds = bounds;
            this.Position = position;
            this.MoveAction = moveAction;
        }

        protected MoveAction MoveAction { get; }

        public Size Bounds { get; set; }

        public Position Position { get; set; }

        public virtual bool IsAlive { get; set; }

        public int PointAffect { get; set; }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public abstract void Draw(Canvas playgroundCanvas);

        public Image CreateImage(string path, Position position, Size bounds)
        {
            Image image = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            image.Source = bitmap;
            image.Width = bounds.Width;
            image.Height = bounds.Height;

            Canvas.SetLeft(image, position.Left);
            Canvas.SetTop(image, position.Top);
            return image;
        }

        public virtual void Move()
        {
            int left = this.Position.Left - ((int)this.MoveAction.Left * this.MoveAction.Speed);
            int top = this.Position.Top - ((int)this.MoveAction.Top * this.MoveAction.Speed);

            this.Position = new Position(left, top);
        }
    }
}