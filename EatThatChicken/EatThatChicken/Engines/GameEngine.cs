namespace EatThatChicken.Engines
{
    using EatThatChicken.GameObjects;
    using EatThatChicken.GameObjects.Birds;
    using EatThatChicken.GameObjects.Bullets;
    using EatThatChicken.GameObjects.Factories;
    using EatThatChicken.GameObjects.Factories.BirdsFactories;
    using EatThatChicken.Misc;
    using EatThatChicken.Renderers;
    using System;
    using System.Collections.Generic;
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

        private List<GameObject> GameObject { get; set; }

        private List<Bullet> Bullets { get; set; }

        private List<Bird> Birds { get; set; }

        private IGameRenderer renderer { get; set; }

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.GameObject = new List<GameObject>();
            this.Bullets = new List<Bullet>();
            this.Birds = new List<Bird>();
        }

        private void UIActionHandler(object sender, KeyDownEventArgs e)
        {
            if (e.Action == GameAction.MoveLeft)
            {
                this.Hunter.MoveLeft = 1;
                if (Hunter.Position.Left < 0)
                {
                    this.Hunter.MoveLeft = 0;
                }
                this.Hunter.Move();
                this.Hunter.MoveLeft = 0;
            }
            else if (e.Action == GameAction.MoveRight)
            {
                this.Hunter.MoveLeft = -1;
                if (Hunter.Position.Left > this.renderer.ScreenWidth - HunterWidth)
                {
                    this.Hunter.MoveLeft = 0;
                }
                this.Hunter.Move();
                this.Hunter.MoveLeft = 0;
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
            this.Bullets.Add(bullet);
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
            this.renderer.Draw(this.Hunter);
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
                this.GameObject.Add(newBird);
                this.Birds.Add(newBird);
            }
            foreach (var bullet in Bullets)
            {
                foreach (var bird in Birds)
                {
                    int bulletTop = 0;
                    int bulletleft = 0;
                    int bulletRight = 0;

                    int birdBottom = 0;
                    int birdleft = 0;
                    int birdRight = 0;

                    bool shouldDie = false;
                    //TODO check collision......
                    if (shouldDie)
                    {
                        bullet.IsAlive = false;
                        bird.IsAlive = false;
                        break;
                    }
                }
            }

            foreach (var gameObj in this.GameObject)
            {
                this.renderer.Draw(gameObj);
                gameObj.Move();
            }
        }

        private void RemoveObject(GameObject anything)
        {
            if (anything.IsAlive == false)
            {
                this.GameObject.Remove(anything);
            }
        }

        private void KillBird(Bird bird, Bullet bullet)
        {
            if (bird.Position.Left == bullet.Position.Left && bird.Position.Top == bullet.Position.Top)
            {
                RemoveObject(bird);
                RemoveObject(bullet);
            }
        }
    }
}
