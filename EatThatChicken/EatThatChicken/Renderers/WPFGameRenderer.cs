using System.Collections.Generic;
using System.Globalization;
using System.Windows.Documents;
using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.GameItems;

namespace EatThatChicken.Renderers
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using EatThatChicken.GameObjects;
    using EatThatChicken.GameObjects.Birds;
    using EatThatChicken.GameObjects.Bullets;
    using EatThatChicken.GameObjects.Hunters;
    using EatThatChicken.Misc;
    using EatThatChicken.View;


    class WPFGameRenderer : IGameRenderer
    {
        private int score = 0;
        private Dictionary<string, string> avatar = new Dictionary<string, string>();

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

            this.avatar.Add("Hunter", "/Images/Hunter.png");
            this.avatar.Add("Bullet", "/Images/Bullet.png");
            this.avatar.Add("AngryBird", "/Images/Birds/angry.png");
            this.avatar.Add("MuscleBird", "/Images/Birds/muscle.png");
            this.avatar.Add("NaughtyBird", "/Images/Birds/naughty.png");
            this.avatar.Add("SkinyBird", "/Images/Birds/skiny.png");
            this.avatar.Add("Bomb", "/Images/bomb.png");
            this.avatar.Add("ChickenLeg", "/Images/chicken-leg.png");
            this.avatar.Add("Heart", "/Images/heart.png");

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

        public void Draw(IEnumerable<IGameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                var image = this.CreateImage(avatar[gameObject.GetType().Name], gameObject.Position, gameObject.Bounds);
                this.playGroundCanvas.Children.Add(image);
            }

            //this.UpdateScore(hunter);
        }

        public bool IsInRange(Position position)
        {
            return 0 <= position.Left && position.Left <= this.ScreenWidth &&
                0 <= position.Top-200 && position.Top <= this.ScreenHeight;
        }

        public void UpdateScore(Hunter hunter)
        {
            var points = $"Points of Player: {hunter.Points}";
            var lifes = $"Lifes: {hunter.NumberOfLifes}";

            this.ShowScoreOnScreen(850, 50, points, Color.FromRgb(255,255,255));
            this.ShowScoreOnScreen(850, 70, lifes, Color.FromRgb(255,255,255));
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
    }
}