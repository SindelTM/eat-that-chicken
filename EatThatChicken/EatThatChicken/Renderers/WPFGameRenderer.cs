using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.GameItems;

namespace EatThatChicken.Renderers
{
    using System;
    using System.Windows;
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
    using System.Collections.Generic;

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
        public event EventHandler<KeyDownEventArgs> UIAction;

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

            (this.playGroundCanvas.Parent as GameFieldWindow).KeyUp += (sender, args) =>
            {
                var key = args.Key;
                if (key == Key.Left)
                {
                        this.UIAction(this, new KeyDownEventArgs(GameAction.StopMoving));
                }
                else if (key == Key.Right)
                {
                        this.UIAction(this, new KeyDownEventArgs(GameAction.StopMoving));
                    
                }
                else if (key == Key.Space)
                {
                        this.UIAction(this, new KeyDownEventArgs(GameAction.StopFire));
                }
            };
        }
        
        public void Clear()
        {
            this.playGroundCanvas.Children.Clear();
        }

        public void Draw(IEnumerable<IGameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.Draw(this.playGroundCanvas);
            }
        }

        public bool IsInRange(Position position)
        {
            return 0 <= position.Left && position.Left <= this.ScreenWidth &&
                0 <= position.Top-200 && position.Top <= this.ScreenHeight;
        }
    }
}