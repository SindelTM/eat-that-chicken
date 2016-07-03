namespace EatThatChicken.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using Contracts;
    using Factories;
    using Factories.BirdsFactories;
    using Factories.ItemsFactory;
    using GameObjects;
    using GameObjects.Birds;
    using GameObjects.Bullets;
    using GameObjects.Hunters;
    using Enumerations;
    using Misc;
  
    public class GameEngine
    {
        
        const int BirdWidth = 60; // This is used to locate where to show up new Bird


        const int TimerIntervalMillis = 30;
        const int GenerateBirdChanse = 5;


        private BulletFactory bulletFactory = new BulletFactory();
        private BirdsFactory birdFactory = new BirdsFactory();
        public ItemGenerator Generator { get; set; }
        private HunterFactory hunterFactory = new HunterFactory();
        private Hunter Hunter { get; set; }

        private List<GameObject> GameObjects { get; set; }
        private List<GameObject> Bullets { get; set; }
        private List<GameObject> Birds { get; set; }

        private IGameRenderer renderer { get; set; }
        private WeaponMode Trigger { get; set; }

        public ICollisionDetector CollisionDetector { get; private set; }

        private Random rand = new Random();
        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObjects = new List<GameObject>();
            this.Bullets = new List<GameObject>();
            this.Birds = new List<GameObject>();
            this.CollisionDetector = new SimpleCollisionDetector();
            this.Generator = new ItemGenerator();
            this.Trigger = WeaponMode.Off;
        }


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
                this.Trigger = WeaponMode.On;
            }
            else if (e.Action == GameAction.StopMoving)
            {
                this.Hunter.StopMove();
            }
            else if (e.Action == GameAction.StopFire)
            {
                this.Trigger = WeaponMode.Off;
            }
        }

        private void FireBullet()
        {
            if (Trigger == WeaponMode.On)
            {
                var left = this.Hunter.Position.Left + this.Hunter.Bounds.Width / 2;
                var top = this.Hunter.Position.Top;
                Bullet newBullet = bulletFactory.Get(left, top);

                this.GameObjects.Add(newBullet);
                this.Bullets.Add(newBullet);
            }
        }

        public void InitGame()
        {
            this.GameObjects.Clear();
            this.Hunter = hunterFactory.Get(this.renderer.ScreenHeight, this.renderer.ScreenWidth);
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
            this.renderer.Clear();
            this.GameObjects.ForEach(x => x.Move());
            this.GameObjects.ForEach(x => x.OutOfScreenUpdate(this.renderer.ScreenHeight, this.renderer.ScreenWidth));
            this.KillIfColliding();
            this.RemoveNotAliveGameObjects();
            this.GenerateItem();
            this.AddBird();
            this.FireBullet();
            this.renderer.Draw(GameObjects);
        }

        private void GenerateItem()
        {
            if (rand.Next(250) < GenerateBirdChanse)
            {
                this.GameObjects.Add(this.Generator.GenerateItems(rand.Next(0, this.renderer.ScreenWidth - 10), 0));
            }
        }

        public void AddBird()
        {
            if (rand.Next(100) < GenerateBirdChanse)
            {
                int left = rand.Next(0, this.renderer.ScreenWidth - BirdWidth);
                int top = 0;
                Bird newBird = birdFactory.Get(left, top);
                this.GameObjects.Add(newBird);
                this.Birds.Add(newBird);
            }
        }

        private void KillIfColliding()
        {
            foreach (var bullet in this.Bullets)
            {
                foreach (var bird in this.Birds)
                {
                    if (CollisionDetector.AreCollided(bird, bullet))
                    {
                        bullet.IsAlive = false;
                        bird.IsAlive = false;
                        break;
                    }
                }
            }            

        }

        private void RemoveNotAliveGameObjects()
        {
            this.GameObjects.RemoveAll(go => !go.IsAlive);
            this.Birds.RemoveAll(bird => !bird.IsAlive);
            this.Bullets.RemoveAll(bullet => !bullet.IsAlive);
        }
    }
}