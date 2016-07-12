namespace EatThatChicken.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using GameObjects.Birds;
    using GameObjects.Bullets;
    using EatThatChicken.Common.Enumerations;
    using EatThatChicken.Common.Events;
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Core;
    using EatThatChicken.Contracts;
    using EatThatChicken.Factories;
    using EatThatChicken.Factories.BirdsFactories;
    using EatThatChicken.Factories.ItemsFactory;

    public class GameEngine
    {
        private const int TimerIntervalMillis = 150;
        private const int GenerationChanse = 20;

        private readonly HunterFactory hunterFactory = new HunterFactory();
        private readonly BulletFactory bulletFactory = new BulletFactory();
        private readonly BirdsFactory birdFactory = new BirdsFactory();
        private readonly Random rand = new Random();

        public GameEngine(IGameRenderer renderer)
        {
            this.Renderer = renderer;
            this.Renderer.UIAction += UIActionHandler;
            this.GameObjects = new List<IGameObject>();
            this.Bullets = new List<IBullet>();
            this.Birds = new List<IBird>();
            this.Items = new List<IGameObject>();
            this.CollisionDetector = new SimpleCollisionDetector();
            this.AffectableGameObjects = new List<IAffectableGameObject>();
            this.Generator = new ItemGenerator();
        }

        private IHunter Hunter { get; set; }

        private List<IGameObject> GameObjects { get; }

        private List<IBullet> Bullets { get; }

        private List<IBird> Birds { get; }

        private List<IGameObject> Items { get; }

        private IGameRenderer Renderer { get; }

        private ICollisionDetector CollisionDetector { get; }

        private IList<IAffectableGameObject> AffectableGameObjects { get; }

        private DispatcherTimer timer;

        public ItemGenerator Generator { get; set; }

        private void UIActionHandler(object sender, KeyDownEventArgs e)
        {
            if (e.Action == GameActionType.MoveLeft)
            {
                if (this.Hunter.Position.Left > 0)
                {
                    this.Hunter.MoveLeft();
                }
            }
            else if (e.Action == GameActionType.MoveRight)
            {
                if (this.Hunter.Position.Left < this.Renderer.ScreenWidth - this.Hunter.Bounds.Width)
                {
                    this.Hunter.MoveRight();
                }
            }
            else if (e.Action == GameActionType.Fire)
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            var left = this.Hunter.Position.Left + this.Hunter.Bounds.Width / 2;
            var top = this.Hunter.Position.Top;
            Bullet newBullet = bulletFactory.Create(left, top);

            this.GameObjects.Add(newBullet);
            this.Bullets.Add(newBullet);
        }

        public void InitGame()
        {
            this.GameObjects.Clear();

            this.CreateHunter();
            
            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(TimerIntervalMillis);
            timer.Tick += this.LoopGame;
        }

        public void StartGame()
        {
            this.timer.Start();
        }

        private void LoopGame(object sender, EventArgs args)
        {
            this.CheckIfHunterIsAlive();
            this.Renderer.Clear();
            this.CollisionDetector.HandleCollisions(this.Bullets, this.Birds, this.Hunter, this.Items);
            this.RemoveGameObjectsOutofScreen();
            this.RemoveNotAliveGameObjects();
            this.GenerateItem();
            this.GenerateBird();
            this.Renderer.UpdateScoreOnRenderer(this.Hunter);
            this.Renderer.Draw(this.GameObjects);
            this.GameObjects.ForEach(x => x.Move());
        }

        private void CheckIfHunterIsAlive()
        {
            if (CollisionDetector.IsHunterColliding(this.Hunter, this.Birds))
            {
                if (this.Hunter.NumberOfLifes == 0)
                {
                    this.timer.Stop();
                    this.Renderer.EndGame(this.Hunter.Points);
                }
            }
        }

        private void GenerateItem()
        {
            if (rand.Next(250) < GenerationChanse)
            {
                var item = this.Generator.GenerateItems(rand.Next(0, this.Renderer.ScreenWidth - 10), 0);
                this.GameObjects.Add(item);
                this.Items.Add(item);
                this.AffectableGameObjects.Add(item);
            }
        }

        public void GenerateBird()
        {
            int left = rand.Next(0, this.Renderer.ScreenWidth);
            int top = 0;
            Bird newBird = birdFactory.Create(left, top);

            left -= newBird.Bounds.Width;
            newBird.Position = new Position(left, top);

            if (rand.Next(100) < GenerationChanse)
            {
                this.GameObjects.Add(newBird);
                this.Birds.Add(newBird);
                this.AffectableGameObjects.Add(newBird);
            }
        }
        
        private void RemoveNotAliveGameObjects()
        {
            this.GameObjects.RemoveAll(go => !go.IsAlive);
            this.Birds.RemoveAll(bird => !bird.IsAlive);
            this.Bullets.RemoveAll(bullet => !bullet.IsAlive);
            this.Items.RemoveAll(item => !item.IsAlive);
        }

        private void RemoveGameObjectsOutofScreen()
        {
            foreach (var gameObject in this.GameObjects)
            {
                if ((gameObject.Position.Top > this.Renderer.ScreenHeight) ||
                    (gameObject.Position.Top + gameObject.Bounds.Height < 0) ||
                    (gameObject.Position.Left > this.Renderer.ScreenWidth) ||
                    (gameObject.Position.Left + gameObject.Bounds.Width < 0))
                {
                    gameObject.IsAlive = false;
                }
            }
        }

        private void CreateHunter()
        {
            this.Hunter = this.hunterFactory.Create(0, 0);

            var hunterWidth = this.Hunter.Bounds.Width;
            var hunterHeight = this.Hunter.Bounds.Height;

            var left = (this.Renderer.ScreenWidth - hunterWidth) / 2;
            var top = this.Renderer.ScreenHeight - hunterHeight;
            var position = new Position(left, top);

            this.Hunter.Position = position;
            this.GameObjects.Add(Hunter);
        }
    }
}
