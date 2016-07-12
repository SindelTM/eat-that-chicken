namespace EatThatChicken.Renderers
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Contracts;
    using View;
    using EatThatChicken.Common.Events;
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Common.Enumerations;


    public class WPFGameRenderer : IWPFGameRenderer
    {
        public event EventHandler<KeyDownEventArgs> UIAction;
        public event EventHandler<EndGameEventArgs> EndGameAction;
        private readonly Dictionary<string, string> avatars;
        private readonly Canvas playGroundCanvas;

        public WPFGameRenderer(Canvas playGroundCanvas)
        {
            this.playGroundCanvas = playGroundCanvas;

            this.avatars = new Dictionary<string, string>();
            FillAvatars();

            (this.playGroundCanvas.Parent as GameFieldWindow).KeyDown += (sender, args) =>
            {
                var key = args.Key;
                if (key == Key.Left)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameActionType.MoveLeft));
                }
                else if (key == Key.Right)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameActionType.MoveRight));
                }
                else if (key == Key.Space)
                {
                    this.UIAction(this, new KeyDownEventArgs(GameActionType.Fire));
                }
            };
        }

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

        private void FillAvatars()
        {
            avatars.Add("Hunter", "/Images/Hunter.png");
            avatars.Add("Bullet", "/Images/Bullet.png");
            avatars.Add("AngryBird", "/Images/Birds/angry.png");
            avatars.Add("MuscleBird", "/Images/Birds/muscle.png");
            avatars.Add("NaughtyBird", "/Images/Birds/naughty.png");
            avatars.Add("SkinyBird", "/Images/Birds/skiny.png");
            avatars.Add("Bomb", "/Images/bomb.png");
            avatars.Add("ChickenLeg", "/Images/chicken-leg.png");
            avatars.Add("Heart", "/Images/heart.png");
        }

        public void Clear()
        {
            this.playGroundCanvas.Children.Clear();
        }

        public void Draw(IEnumerable<IGameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var image = this.CreateImage(avatars[gameObject.GetType().Name], gameObject.Position, gameObject.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }
        }

       /* public bool IsInRange(Position position)
        {
            return 0 <= position.Left && position.Left <= this.ScreenWidth &&
                0 <= position.Top - 200 && position.Top <= this.ScreenHeight;
        }*/

        public void UpdateScoreOnRenderer(IHunter hunter)
        {
            var points = hunter.Points.ToString();
            var lifes = hunter.NumberOfLifes.ToString();

            this.ShowScoreOnScreen(900, 30, points, Color.FromRgb(255, 255, 255));
            this.ShowScoreOnScreen(900, 60, lifes, Color.FromRgb(255, 255, 255));
        }

        private void ShowScoreOnScreen(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock(new Bold());
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            this.playGroundCanvas.Children.Add(textBlock);
        }

        private Image CreateImage(string path, Position position, Size bounds)
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

        public void EndGame(int points)
        {
            this.EndGameAction(this, new EndGameEventArgs(points));
        }
    }
}