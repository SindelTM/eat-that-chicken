using EatThatChicken.Engines;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.Renderers;
using EatThatChicken.View;

namespace EatThatChicken.ViewModel
{
    class GameFieldViewModel
    {
        private GameEngine Engine { get; set; }

        public GameFieldViewModel(GameFieldWindow window)
        {
            var renderer = new WPFGameRenderer(window.PlayGroundCanvas);
            this.Engine = new GameEngine(renderer);

            Position birdPosition = new Position((int)(window.Width / 2), (int)window.Height);
            Size birdSize = new Size(15, 15);
            var bird = new Bird(birdSize, birdPosition, true, 100);
            renderer.Draw(bird);
            //this.Engine.InitGame();
            //this.Engine.StartGame();
        }
    }
}
