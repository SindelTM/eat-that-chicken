﻿using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class Bomb : Item
    {
        private const int defaultSpeed = 1;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        public Bomb(Size bounds, Position position)
            : base(bounds, position, moveaction) { }


        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/bomb.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
