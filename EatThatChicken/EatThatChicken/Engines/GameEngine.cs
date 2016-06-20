﻿using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.GameObjects.Bullets;
using EatThatChicken.GameObjects.Factories;
using EatThatChicken.Misc;
using EatThatChicken.Renderers;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace EatThatChicken.Engines
{
    class GameEngine
    {
        //TODO Use Move() method when implemented
        const int HunterSpeed = 15;
        //TODO Use Hunter Factory when implemented
        const int HunterHeight = 150;
        const int HunterWidth = 50;
        const int HunterPoints = 100;

        //TODO Use Move() method when implemented
        const int BulletSpeed = 40;

        const int TimerIntervalMillis = 100;

        private BulletFactory bulletFactory = new BulletFactory();

        //TODO Use Hunter type instead when implemented
        private Bird Hunter { get; set; }

        private List<GameObject> Bullets { get; set; }

        private IGameRenderer renderer { get; set; }

        private DispatcherTimer timer;

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
            this.renderer.UIAction += UIActionHandler;
            this.Bullets = new List<GameObject>();
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
                FireBullet();
            }
        }

        private void FireBullet()
        {
            var left = this.Hunter.Position.Left - HunterWidth / 2;
            var top = this.Hunter.Position.Top;
            Bullet bullet = bulletFactory.Get(left, top);

            this.Bullets.Add(bullet);
        }

        public void InitGame()
        {
            this.Bullets.Clear();

            var left = (this.renderer.ScreenWidth - HunterWidth) / 2;
            var top = this.renderer.ScreenHeight - HunterHeight;
            Position position = new Position(left, top);

            Size bounds = new Size(HunterWidth, HunterHeight);

            this.Hunter = new Bird(bounds, position, true, 100);

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
            this.DrawBullets();
        }

        private void DrawBullets()
        {
            foreach (var bullet in this.Bullets)
            {
                var left = this.Hunter.Position.Left + this.Hunter.Bounds.Width / 2;
                var top = bullet.Position.Top - BulletSpeed;
                bullet.Position = new Position(left, top);
                this.renderer.Draw(bullet);
            }
        }
    }
}
