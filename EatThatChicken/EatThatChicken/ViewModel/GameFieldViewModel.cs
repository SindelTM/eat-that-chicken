namespace EatThatChicken.ViewModel
{
    using EatThatChicken.Engines;
    using EatThatChicken.Renderers;
    using EatThatChicken.View;
    using EatThatChicken.Common.Events;

    class GameFieldViewModel
    {
        private GameEngine Engine { get; set; }

        private readonly GameFieldWindow window;

        public GameFieldViewModel(GameFieldWindow window)
        {
            this.window = window;

            var renderer = new WPFGameRenderer(this.window.PlayGroundCanvas);
            renderer.EndGameAction += this.EndGameActionHandler;
            this.Engine = new GameEngine(renderer);

            this.Engine.InitGame();
            this.Engine.StartGame();
        }

        private void EndGameActionHandler(object sender, EndGameEventArgs args)
        {
            int points = args.Points;
            EndGameWindow endGameWnd = new EndGameWindow(points);
            endGameWnd.Show();
            this.window.Close();
        }
    }
}
