﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;
using Size = EatThatChicken.Common.Size;

namespace EatThatChicken.GameObjects.Bullets
{
    using Enumerations;

    public class Bullet : GameObject, IBullet
    {
        private const int defaultSpeed = 40;
        private const MoveType defaultTop = MoveType.Incremental;
        private const MoveType defaultLeft = MoveType.None;

        public Bullet(Size bounds, Position position)
            : base(bounds, position, new MoveAction(defaultLeft, defaultTop, defaultSpeed)) { }
    }
}