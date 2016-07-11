namespace EatThatChicken.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using GameObjects.Birds;
    using GameObjects.Bullets;
    using GameObjects.Hunters;
    using Misc;
    using EatThatChicken.Common;
    using EatThatChicken.Contracts;
    using EatThatChicken.Factories;
    using EatThatChicken.Factories.BirdsFactories;
    using EatThatChicken.Factories.ItemsFactory;


    public class GameEngine
    {
        private const int TimerIntervalMillis = 150;
        private const int GenerateBirdChanse = 20;

        private readonly HunterFactory hunterFactory = new HunterFactory();

        private readonly BulletFactory bulletFactory = new BulletFactory();

        private readonly BirdsFactory birdFactory = new BirdsFactory();

        private Hunter Hunter { get; set; }

        private List<IGameObject> GameObjects { get; }

        private List<IGameObject> Bullets { get; }

        private List<IGameObject> Birds { get; }

        private List<IGameObject> Items { get; }

        private IGameRenderer renderer { get; }

        private ICollisionDetector CollisionDetector { get; }

        private IList<IAffectableGameObject> AffectableGameObjects { get; }

        private readonly Random rand = new Random();

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObjects = new List<IGameObject>();
            this.Bullets = new List<IGameObject>();
            this.Birds = new List<IGameObject>();
            this.Items = new List<IGameObject>();
            this.CollisionDetector = new SimpleCollisionDetector();
            this.AffectableGameObjects = new List<IAffectableGameObject>();
            this.Generator = new ItemGenerator();
        }

        public ItemGenerator Generator { get; set; }

        private void UIActionHandler(object sender, KeyDownEventArgs e)
        {
            if (e.Action == GameAction.MoveLeft)
            {
                if (this.Hunter.Position.Left > 0)
                {
                    this.Hunter.MoveLeft();
                }
            }
            else if (e.Action == GameAction.MoveRight)
            {
                if (this.Hunter.Position.Left < this.renderer.ScreenWidth - this.Hunter.Bounds.Width)
                {
                    this.Hunter.MoveRight();
                }
            }
            else if (e.Action == GameAction.Fire)
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

            // TO DO add Hunter
            this.Hunter = this.hunterFactory.Create(0, 0);

            var hunterWidth = this.Hunter.Bounds.Width;
            var hunterHeight = this.Hunter.Bounds.Height;

            var left = (this.renderer.ScreenWidth - hunterWidth) / 2;
            var top = this.renderer.ScreenHeight - hunterHeight;
            var position = new Position(left, top);

            this.Hunter.Position = position;

            this.GameObjects.Add(Hunter);
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
            if (CollisionDetector.isHunterColliding(this.Hunter, this.Birds))
            {
                if (this.Hunter.NumberOfLifes > 0 && this.Hunter.NumberOfLifes <= 3)
                {
                    this.Hunter.NumberOfLifes--;
                }
                else if (this.Hunter.NumberOfLifes == 0)
                {
                    this.timer.Stop();
                    this.renderer.EndGame(this.Hunter.Points);
                }
            }
            this.renderer.Clear();
            this.CollisionDetector.KillIfColliding(this.Bullets, this.Birds);
            this.CollisionDetector.HandleCollision(this.Hunter, this.Items);
            this.RemoveGameObjectsOutofScreen();
            this.RemoveNotAliveGameObjects();
            this.GenerateItem();
            this.AddBird();
            this.renderer.UpdateScore(this.Hunter);
            this.renderer.Draw(this.GameObjects);
            this.GameObjects.ForEach(x => x.Move());

        }

        private void GenerateItem()
        {
            if (rand.Next(250) < GenerateBirdChanse)
            {
                var item = this.Generator.GenerateItems(rand.Next(0, this.renderer.ScreenWidth - 10), 0, this.Hunter);
                this.GameObjects.Add(item);
                this.Items.Add(item);
                this.AffectableGameObjects.Add(item);
            }
        }

        public void AddBird()
        {
            int left = rand.Next(0, this.renderer.ScreenWidth);
            int top = 0;
            Bird newBird = birdFactory.Create(left, top);

            left -= newBird.Bounds.Width;
            newBird.Position = new Position(left, top);

            if (rand.Next(100) < GenerateBirdChanse)
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
                if ((gameObject.Position.Top > this.renderer.ScreenHeight) ||
                    (gameObject.Position.Top + gameObject.Bounds.Height < 0) ||
                    (gameObject.Position.Left > this.renderer.ScreenWidth) ||
                    (gameObject.Position.Left + gameObject.Bounds.Width < 0))
                {
                    gameObject.IsAlive = false;
                }
            }
        }

    }
}
