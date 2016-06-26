namespace EatThatChicken.ViewModel
{
    using EatThatChicken.Engines;
    using EatThatChicken.Renderers;
    using EatThatChicken.View;

    class GameFieldViewModel
    {
        private GameEngine Engine { get; set; }

        public GameFieldViewModel(GameFieldWindow window)
        {
            var renderer = new WPFGameRenderer(window.PlayGroundCanvas);
            this.Engine = new GameEngine(renderer);

            this.Engine.InitGame();
            this.Engine.StartGame();
        }
    }
}
