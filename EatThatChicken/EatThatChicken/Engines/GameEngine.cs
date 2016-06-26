namespace EatThatChicken.Engines
{
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
    using System.Linq;
    using System.Windows.Threading;

    public class GameEngine
    {
        //TODO Use Move() method when implemented
        const int HunterSpeed = 15;
        //TODO Use Hunter Factory when implemented
        const int HunterHeight = 190;
        const int HunterWidth = 90;
        const int HunterPoints = 100;

        const int BirdWidth = 60; // This is used to locate where to show up new Bird

        const int TimerIntervalMillis = 150;
        const int GenerateBirdChanse = 20;

        private BulletFactory bulletFactory = new BulletFactory();

        private BirdsFactory birdFactory = new BirdsFactory();

        private Hunter Hunter { get; set; }

        private List<GameObject> GameObjects { get; set; }

        private List<GameObject> Bullets { get; set; }

        private List<GameObject> Birds { get; set; }

        private IGameRenderer renderer { get; set; }

        public ICollisionDetector CollisionDetector { get; private set; }

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObjects = new List<GameObject>();
            this.Bullets = new List<GameObject>();
            this.Birds = new List<GameObject>();
            this.CollisionDetector = new SimpleCollisionDetector();
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
                if (this.Hunter.Position.Left < this.renderer.ScreenWidth - HunterWidth)
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
            var left = this.Hunter.Position.Left + HunterWidth / 2;
            var top = this.Hunter.Position.Top;
            Bullet newBullet = bulletFactory.Get(left, top);

            foreach (var bullet in Bullets)
            {
                if (!this.renderer.IsInRange(bullet.Position))
                {
                    bullet.IsAlive = false;
                }
            }

            this.GameObjects.Add(newBullet);
            this.Bullets.Add(newBullet);
        }

        public void InitGame()
        {
            this.GameObjects.Clear();

            var left = (this.renderer.ScreenWidth - HunterWidth) / 2;
            var top = this.renderer.ScreenHeight - HunterHeight;
            Position position = new Position(left, top);

            Size bounds = new Size(HunterWidth, HunterHeight);

            // TO DO add Hunter
            this.Hunter = new Hunter(bounds, position);
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
            this.renderer.Draw(this.Hunter);
            this.KillIfColliding();
            this.RemoveNotAliveGameObjects();
            this.AddBird();

        }

        public void AddBird()
        {
            Random rand = new Random();

            int left = rand.Next(0, this.renderer.ScreenWidth - BirdWidth);
            int top = 0;
            Bird newBird = birdFactory.Get(left, top);

            if (rand.Next(100) < GenerateBirdChanse)
            {
                this.GameObjects.Add(newBird);
                this.Birds.Add(newBird);
            }
            
            foreach (var gameObj in this.GameObjects)
            {
                this.renderer.Draw(gameObj);
                gameObj.Move();
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
