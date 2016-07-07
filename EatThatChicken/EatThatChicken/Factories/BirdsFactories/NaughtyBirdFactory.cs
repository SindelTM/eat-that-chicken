﻿namespace EatThatChicken.Factories.BirdsFactories
{
    using Contracts;
    using GameObjects;
    using GameObjects.Birds;

    public class NaughtyBirdFactory : IGameObjectFactory<NaughtyBird>
    {
        // TODO: see if width, height is enough
        private const int NaughtyBirdBoundsWidth = 60;
        private const int NaughtyBirdBoundsHeight = 70;

        private const int NaughtyBirdSpeed = 6;

        public NaughtyBird Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(NaughtyBirdBoundsWidth, NaughtyBirdBoundsWidth);

            return new NaughtyBird(bounds, position, NaughtyBirdSpeed);
        }
    }
}