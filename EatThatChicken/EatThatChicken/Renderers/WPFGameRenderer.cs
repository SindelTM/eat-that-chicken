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

namespace EatThatChicken.Renderers
{
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
                    rect.Fill = Brushes.Black;
                }
                else if (gameObject is Bullet)
                {
                    rect.Fill = Brushes.Red;
                }

                this.playGroundCanvas.Children.Add(rect);
            }
        }
    }
}
