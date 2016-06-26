namespace EatThatChicken.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using GameObjects;
    using GameObjects.Birds;
    using GameObjects.Bullets;
    using GameObjects.Factories;
    using GameObjects.Factories.BirdsFactories;
    using GameObjects.Hunters;
    using Misc;
    using Renderers;
    using System.Linq;

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

        private static int leftPositionOfBird;

        private BulletFactory bulletFactory = new BulletFactory();

        private BirdsFactory birdFactory = new BirdsFactory();

        private Hunter Hunter { get; set; }

        private List<GameObject> GameObjects { get; set; }

        private List<GameObject> Bullets { get; set; }

        private List<Bird> BirdsInTop { get; set; }

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
            this.BirdsInTop = new List<Bird>();
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
            this.RemoveBirdsAndBulletsOutofScreen();
            this.RemoveNotAliveGameObjects();
            this.AddBird();

        }

        public void AddBird()
        {
            Random rand = new Random();

        //    int left = rand.Next(0, this.renderer.ScreenWidth - BirdWidth);
            int left = GetNextLeft();
            int top = 0;
          
            Bird newBird = birdFactory.Get(left, top);
            leftPositionOfBird = newBird.Position.Left;

                if (rand.Next(100) < GenerateBirdChanse)
                {
                    this.GameObjects.Add(newBird);
                    this.BirdsInTop.Add(newBird);
                    this.Birds.Add(newBird);
                }

                foreach (var gameObj in this.GameObjects)
                {
                    this.renderer.Draw(gameObj);
                    gameObj.Move();
                }

            BirdsInTop.RemoveAll(b => b.Position.Top > b.Bounds.Height);

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

        private void RemoveBirdsAndBulletsOutofScreen()
        {
            foreach (var bird in this.Birds)
            {
                if (bird.Position.Top > (this.Hunter.Position.Top + this.Hunter.Bounds.Height))
                {
                    bird.IsAlive = false;
                    break;
                }
            }
            foreach (var bullet in this.Bullets)
            {
                if (bullet.Position.Top + bullet.Bounds.Height < 0)
                {
                    bullet.IsAlive = false;
                    break;
                }
            }


        }

        private int GetNextLeft()
        {
            BirdsInTop = BirdsInTop.OrderBy(b => b.Position.Left).ToList();

            int currentSpace = 0;
            
            int maxSpace = 0;
            int maxSpaceIndex = 0;

            for (int index = 0; index < BirdsInTop.Count - 1; index++)
            {

                if (index == 0)
                {
                    currentSpace = BirdsInTop[index].Position.Left;
                }
                else if (index == BirdsInTop.Count - 2)
                {
                    currentSpace = renderer.ScreenWidth - BirdsInTop[index + 1].Position.Left;
                }
                else
                {
                    currentSpace = BirdsInTop[index + 1].Position.Left - BirdsInTop[index].Position.Left;
                }
                
                if (currentSpace > BirdsInTop[index].Bounds.Width * 3 && currentSpace > maxSpace)
                {
                    maxSpace = currentSpace;
                    maxSpaceIndex = index;
                }


            }
            int initialSpace = 0;
            int lastSpace = 0;

            if (BirdsInTop.Count > 0)
            {
                initialSpace = BirdsInTop[0].Position.Left;
                lastSpace = renderer.ScreenWidth - (BirdsInTop[BirdsInTop.Count - 1].Position.Left + BirdsInTop[BirdsInTop.Count - 1].Bounds.Width);
            }



            int startRange = 0;
            int endRange = renderer.ScreenWidth;

            if (initialSpace > lastSpace && initialSpace > maxSpace)
            {
                endRange = BirdsInTop[0].Position.Left;              
            }
            else if(lastSpace > initialSpace && lastSpace > maxSpace)
            {
                startRange = BirdsInTop[BirdsInTop.Count - 1].Position.Left + BirdsInTop[BirdsInTop.Count - 1].Bounds.Width;
            }
            else if (maxSpace > initialSpace && maxSpace > lastSpace)
            {
                Bird firstBird = BirdsInTop[maxSpaceIndex];
                startRange = firstBird.Position.Left + firstBird.Bounds.Width;
                Bird lastBird = BirdsInTop[maxSpaceIndex + 1];
                endRange = lastBird.Position.Left - lastBird.Bounds.Width;
            }




            //if (BirdsInTop.Count > 1 && maxSpace > BirdsInTop[0].Bounds.Width)
            //{

            //    Bird firstBird = BirdsInTop[maxSpaceIndex];
            //    startRange = firstBird.Position.Left + firstBird.Bounds.Width;
            //    Bird lastBird = BirdsInTop[maxSpaceIndex + 1];
            //    endRange = lastBird.Position.Left - lastBird.Bounds.Width;
            //}

            Random rand = new Random();
            int result = rand.Next(startRange, endRange);

            return result;
        }

    }
}
