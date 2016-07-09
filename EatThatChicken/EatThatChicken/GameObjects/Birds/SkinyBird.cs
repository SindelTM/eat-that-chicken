﻿using EatThatChicken.Common;

namespace EatThatChicken.GameObjects.Birds
{
    using System.Windows.Controls;

    public class SkinyBird: Bird
    {
        private const int SkinnyBirdDefaultHealth = 1;

        private const int SkinnyBirdDefaultScore = 1;

        public SkinyBird(Size bounds, Position position, int speed)
            : base(SkinnyBirdDefaultHealth, SkinnyBirdDefaultScore, bounds, position, speed)
        {
            this.PointAffect = SkinnyBirdDefaultScore;
        }

        public override void Draw(Canvas playGroundCanvas)
        {
            var image = this.CreateImage("/Images/Birds/skiny.png", this.Position, this.Bounds);
            playGroundCanvas.Children.Add(image);
        }
    }
}
