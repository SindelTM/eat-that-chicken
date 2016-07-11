﻿using EatThatChicken.Common;
using EatThatChicken.Common.Structs;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Bullets;

namespace EatThatChicken.Factories
{
    public class BulletFactory : IGameObjectFactory<Bullet>
    {
        const int bulletWidth = 10;
        const int bulletHeight = 30;

        public Bullet Create(int left, int top)
        {
            Position position = new Position(left - (bulletWidth / 2), top - bulletHeight);
            Size bounds = new Size(bulletWidth, bulletHeight);

            return new Bullet(bounds, position);
        }
    }
}