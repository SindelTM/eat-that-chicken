using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.Misc;
using EatThatChicken.Renderers;
using System;
using System.Windows.Threading;

namespace EatThatChicken.Engines
{
    class GameEngine
    {
        const int HunterSpeed = 15;
        const int HunterHeight = 150;
        const int HunterWidth = 50;
        const int HunterPoints = 100;
        const int TimerIntervalMillis = 100;

        //TODO Use Hunter type instead when implemented
        private Bird Hunter { get; set; }

        private IGameRenderer renderer { get; set; }

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
        }

        private void UIActionHandler(object sender, KeyDownEventArgs e)
        {
            if (e.Action == GameAction.MoveLeft)
            {
                int left = this.Hunter.Position.Left - HunterSpeed;
                int top = this.Hunter.Position.Top;
                Position newPosition = new Position(left, top);
                this.Hunter.Position = newPosition;
            }
            else if (e.Action == GameAction.MoveRight)
            {
                int left = this.Hunter.Position.Left + HunterSpeed;
                int top = this.Hunter.Position.Top;
                Position newPosition = new Position(left, top);
                this.Hunter.Position = newPosition;
            }
            else if (e.Action == GameAction.Fire)
            {

            }
        }

        public void InitGame()
        {
            Size bounds = new Size(HunterWidth, HunterHeight);
            Position posiotion = new Position((this.renderer.ScreenWidth - HunterWidth) / 2, this.renderer.ScreenHeight - HunterHeight);
            this.Hunter = new Bird(bounds, posiotion, true, 100);

            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMillis);
            timer.Tick += GameLoop;
        }

        public void StartGame()
        {
            this.timer.Start();
        }

        private void GameLoop(object sender, EventArgs args)
        {
            this.renderer.Clear();
            this.renderer.Draw(this.Hunter);
        }
    }
}
