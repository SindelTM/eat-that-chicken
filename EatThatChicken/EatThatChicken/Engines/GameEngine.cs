using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.GameObjects.Bullets;
using EatThatChicken.GameObjects.Factories;
using EatThatChicken.GameObjects.Factories.BirdsFactories;
using EatThatChicken.GameObjects.Hunters;
using EatThatChicken.Misc;
using EatThatChicken.Renderers;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace EatThatChicken.Engines
{
    public class GameEngine
    {
        //TODO Use Move() method when implemented
        const int HunterSpeed = 15;
        //TODO Use Hunter Factory when implemented
        const int HunterHeight = 190;
        const int HunterWidth = 90;
        const int HunterPoints = 100;

        const int BirdWidth = 60; // This is used to locate where to show up new Bird

        const int TimerIntervalMillis = 100;

        private BulletFactory bulletFactory = new BulletFactory();

        private BirdsFactory birdFactory = new BirdsFactory();

        private Hunter Hunter { get; set; }

        private List<GameObject> GameObject { get; set; }

        private IGameRenderer renderer { get; set; }

        private DispatcherTimer timer;

        static readonly Random rand = new Random();

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObject = new List<GameObject>();
        }

        private void UIActionHandler(object sender, KeyDownEventArgs e)
        {
            if (e.Action == GameAction.MoveLeft)
            {
                this.Hunter.MoveLeft();
            }
            else if (e.Action == GameAction.MoveRight)
            {
                this.Hunter.MoveRight();
            }
            else if (e.Action == GameAction.Fire)
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            var left = this.Hunter.Position.Left + HunterWidth / 2;
            var top = this.Hunter.Position.Top;
            Bullet bullet = bulletFactory.Get(left, top);

            this.GameObject.Add(bullet);
        }

        public void InitGame()
        {
            this.GameObject.Clear();

            var left = (this.renderer.ScreenWidth - HunterWidth) / 2;
            var top = this.renderer.ScreenHeight - HunterHeight;
            Position position = new Position(left, top);

            Size bounds = new Size(HunterWidth, HunterHeight);

            // TO DO add Hunter
            this.Hunter = new Hunter(bounds, position);
            this.GameObject.Add(Hunter);
            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMillis);
            timer.Tick += this.GameLoop;
        }

        public void StartGame()
        {
            this.timer.Start();
        }

        private void GameLoop(object sender, EventArgs args)
        {
            this.renderer.Clear();
            //this.renderer.Draw(this.Hunter);
            int left = rand.Next(0, this.renderer.ScreenWidth - BirdWidth);
            int top = 0;
            GameObject bird = birdFactory.Get(left, top);
            this.GameObject.Add(bird);
            foreach (var gameObj in this.GameObject) 
            {
                this.renderer.Draw(gameObj);
                gameObj.Move();
            }
        }
    }
}
