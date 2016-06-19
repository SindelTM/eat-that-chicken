using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using EatThatChicken.GameObjects;
using System.Windows.Shapes;
using System.Windows.Media;

namespace EatThatChicken.Renderers
{
    class WPFGameRenderer : IGameRenderer
    {
        private Canvas playGroundCanvas;

        public WPFGameRenderer(Canvas playGroundCanvas)
        {
            this.playGroundCanvas = playGroundCanvas;
        }

        public event EventHandler UIAction;

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
                    Height = gameObject.Bounds.Height,
                    Fill = Brushes.Black
                };

                Canvas.SetLeft(rect, gameObject.Position.Left);
                Canvas.SetTop(rect, gameObject.Position.Top);

                this.playGroundCanvas.Children.Add(rect);
            }
        }

        public void UIActionHandler(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
