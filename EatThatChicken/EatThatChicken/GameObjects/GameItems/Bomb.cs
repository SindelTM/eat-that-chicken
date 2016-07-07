﻿using System.Windows.Controls;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class Bomb : Item
    {
        public Bomb(int speed, Size bounds, Position position)
            : base(bounds, position, speed) { }


        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/bomb.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
