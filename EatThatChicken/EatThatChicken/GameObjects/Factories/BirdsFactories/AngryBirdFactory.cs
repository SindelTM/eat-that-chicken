﻿namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    using EatThatChicken.Contracts;
    using EatThatChicken.GameObjects.Birds;

    public class AngryBirdFactory : IGameObjectFactory<AngryBird>
    {
        // TODO: see if width, height is enough
        private const int AngryBirdBoundsWidth = 60;
        private const int AngryBirdBoundsHeight = 70;

        public AngryBird Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(AngryBirdBoundsWidth, AngryBirdBoundsHeight);

            return new AngryBird(bounds, position);
        }
    }
}
