﻿using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Enumerations;

    public class SkinyBird: Bird
    {
        private const int defaultSpeed = 6;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        private const int SkinnyBirdHealth = 1;

        public SkinyBird(Size bounds, Position position)
            : base(SkinnyBirdHealth, bounds, position, moveaction) { }

        public override void Draw(Canvas playGroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/skiny.png", this.Position, this.Bounds);
            playGroundCanvas.Children.Add(image);
        }
    }
}
