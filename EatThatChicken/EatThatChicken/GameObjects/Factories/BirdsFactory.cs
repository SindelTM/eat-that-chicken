using System;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects.Factories
{
    public class BirdsFactory: IGameObjectFactory<Bird>
    {
        // TODO: see if width,height and appearance is enough
        private const int Count = 100;

        private const int BirdBoundsWidth = 60;
        private const int BirdBoundsHeight = 70;

        private const int SkinyBirdBoundsWidth = 60;
        private const int SkinyBirdBoundsHeight = 70;

        private const int AngryBirdBoundsWidth = 60;
        private const int AngryBirdBoundsHeight = 70;

        private const int MuscleBirdBoundsWidth = 60;
        private const int MuscleBirdBoundsHeight = 70;

        private const int NaughtyBirdBoundsWidth = 60;
        private const int NaughtyBirdBoundsHeight = 70;

        private const int SkinyBirdAppearanceChance = 16;
        private const int AngryBirdAppearanceChance = 15;
        private const int MuscleBirdAppearanceChance = 10;
        private const int NaughtyBirdAppearanceChance = 12;

        static readonly Random rand = new Random();

        public Bird Get(int left, int top)
        {
            if (rand.Next(Count) <= SkinyBirdAppearanceChance)
            {
                if (rand.Next(Count) < AngryBirdAppearanceChance)
                {
                    return new AngryBird()
                    {
                        Position = new Position(left, top),
                        Bounds = new Size(AngryBirdBoundsWidth, AngryBirdBoundsHeight)
                    };
                }
                else if (rand.Next(Count) < MuscleBirdAppearanceChance)
                {
                    return new MuscleBird()
                    {
                        Position = new Position(left, top),
                        Bounds = new Size(MuscleBirdBoundsWidth, MuscleBirdBoundsHeight)
                    };
                }
                else if (rand.Next(Count) < NaughtyBirdAppearanceChance)
                {
                    return new NaughtyBird()
                    {
                        Position = new Position(left, top),
                        Bounds = new Size(NaughtyBirdBoundsWidth, NaughtyBirdBoundsHeight)
                    };
                }

            }

            return new SkinyBird()
            {
                Position = new Position(left, top),
                Bounds = new Size(SkinyBirdBoundsWidth, SkinyBirdBoundsHeight)
            };
        }
    }
}