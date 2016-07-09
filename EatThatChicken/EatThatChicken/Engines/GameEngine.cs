using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.Factories;
using EatThatChicken.Factories.BirdsFactories;
using EatThatChicken.Factories.ItemsFactory;

namespace EatThatChicken.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using GameObjects;
    using GameObjects.Birds;
    using GameObjects.Bullets;
    using GameObjects.Hunters;
    using Misc;


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

        private List<Bird> Birds { get; }
        
        private IGameRenderer renderer { get; }

        public ICollisionDetector CollisionDetector { get; private set; }

        private IList<IAffectableGameObject> AffectableGameObjects { get; set; } 

        private readonly Random rand = new Random();

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObjects = new List<IGameObject>();
            this.Bullets = new List<IGameObject>();
            this.Birds = new List<Bird>();
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
            this.renderer.Clear();
            this.renderer.Draw(this.Hunter);
            this.KillIfColliding();
            this.CollisionDetector.HandleCollision(this.Hunter, this.GameObjects);
            this.RemoveBirdsOutofScreen();
            this.RemoveNotAliveGameObjects();
            this.GenerateItem();
            this.AddBird();
            this.renderer.UpdateScore(this.Hunter);
            foreach (var gameObj in this.GameObjects)
            {
                this.renderer.Draw(gameObj);
                gameObj.Move();
                
            }
        }

        private void GenerateItem()
        {
            if (rand.Next(250) < GenerateBirdChanse)
            {
                var item = this.Generator.GenerateItems(rand.Next(0, this.renderer.ScreenWidth - 10), 0, this.Hunter);
                this.GameObjects.Add(item);
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

        private void RemoveBirdsOutofScreen()
        {
            foreach (var bird in this.Birds)
            {
                if (bird.Position.Top > (this.Hunter.Position.Top + this.Hunter.Bounds.Height))
                {
                    bird.IsAlive = false;
                    break;
                }
            }
        }

    }
}
