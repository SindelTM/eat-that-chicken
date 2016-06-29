using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EatThatChicken.GameObjects
{
    using EatThatChicken.Contracts;

    public abstract class GameObject : IGameObject
    {
        protected readonly MoveAction moveAction;

        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position, MoveAction moveAction)
            : this()
        {
            this.Bounds = bounds;
            this.Position = position;
            this.moveAction = moveAction;
        }

        public MoveAction MoveAction { get; }

        public Size Bounds { get; set; }
        public Position Position { get; set; }
        public virtual bool IsAlive { get; set; }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        

        public abstract void Draw(Canvas playgroundCanvas);

        public Image CreateImage(string path, Position position, GameObjects.Size bounds)
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
            int left = this.Position.Left - ((int)this.moveAction.Left * this.moveAction.Speed);
            int top = this.Position.Top - ((int)this.moveAction.Top * this.moveAction.Speed);

            this.Position = new Position(left, top);
        }
    }
}