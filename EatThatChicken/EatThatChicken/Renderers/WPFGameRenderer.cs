namespace EatThatChicken.Renderers
{
    using System;
    using System.Windows.Controls;
    using EatThatChicken.GameObjects;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using EatThatChicken.View;
    using System.Windows.Input;
    using EatThatChicken.Misc;
    using EatThatChicken.GameObjects.Birds;
    using EatThatChicken.GameObjects.Bullets;
    using System.Windows;
    using System.Windows.Media.Imaging;

    class WPFGameRenderer : IGameRenderer
    {
        public int ScreenHeight
        {
            get
            {
                return (int)(this.playGroundCanvas.Parent as GameFieldWindow).Height;
            }
        }

        public int ScreenWidth
        {
            get
            {
                return (int)(this.playGroundCanvas.Parent as GameFieldWindow).Width;
            }
        }

        private Canvas playGroundCanvas;

        public WPFGameRenderer(Canvas playGroundCanvas)
        {
            this.playGroundCanvas = playGroundCanvas;

            (this.playGroundCanvas.Parent as GameFieldWindow).KeyDown += (sender, args) =>
            {
                var key = args.Key;
                if (key == Key.Left)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameAction.MoveLeft));
                }
                else if (key == Key.Right)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameAction.MoveRight));
                }
                else if (key == Key.Space)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameAction.Fire));
                }
            };
        }

        public event EventHandler<KeyDownEventArgs> UIAction;

        public void Clear()
        {
            this.playGroundCanvas.Children.Clear();
        }

        public void Draw(params GameObject[] gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var rect = new Rectangle
                {
                    Width = gameObject.Bounds.Width,
                    Height = gameObject.Bounds.Height
                };

                Canvas.SetLeft(rect, gameObject.Position.Left);
                Canvas.SetTop(rect, gameObject.Position.Top);

                if (gameObject is Bird)
                {
                    this.DrawBird(gameObject);
                }
                else if (gameObject is Bullet)
                {
                    this.DrawBullet(gameObject);
                }
                else if (gameObject is Hunter)
                {
                    this.DrawHunter(gameObject);
                }
                this.playGroundCanvas.Children.Add(rect);
            }
        }
        private void DrawBird(GameObject bird)
        {

            if (bird is AngryBird)
            {
                var image = this.CreateImage("/Images/Birds/angry.png", bird.Position, bird.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }
            if (bird is SkinyBird)
            {
                var image = this.CreateImage("/Images/Birds/skiny.png", bird.Position, bird.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }
            if (bird is MuscleBird)
            {
                var image = this.CreateImage("/Images/Birds/muscle.png", bird.Position, bird.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }
            if (bird is NaughtyBird)
            {
                var image = this.CreateImage("/Images/Birds/naughty.png", bird.Position, bird.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }


        }

        private void DrawHunter(GameObject sindel)
        {
            var image = this.CreateImage("/Images/Sindel.png", sindel.Position, sindel.Bounds);
            this.playGroundCanvas.Children.Add(image);
        }

        private void DrawBullet(GameObject bullet)
        {
             var rect = new Border
            {
                Width = bullet.Bounds.Width,
                Height = bullet.Bounds.Height,
                Background = Brushes.White,
                CornerRadius = new CornerRadius(10, 10, 0, 0)
            };

            Canvas.SetLeft(rect, bullet.Position.Left);
            Canvas.SetTop(rect, bullet.Position.Top);
            this.playGroundCanvas.Children.Add(rect);
        }

        private Image CreateImage(string path, Position position, GameObjects.Size bounds)
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
    }
}