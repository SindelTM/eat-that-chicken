using System;
using EatThatChicken.GameObjects.Birds;
using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects.Factories.BirdsFactories
{
    public class BirdsFactory: IGameObjectFactory<Bird>
    {
        // TODO: see if appearance of birds is OK
        static readonly Random rand = new Random();
        private const int Count = 100;

        // 30 skinyBirds
        private const int SkinyBirdAppearanceMin = 0;
        private const int SkinyBirdAppearanceMax = 30;

        // 30 angryBird
        private const int AngryBirdAppearanceMin = 31;
        private const int AngryBirdAppearanceMax = 60;

        // 15 muscleBird
        private const int MuscleBirdAppearanceMin = 61;
        private const int MuscleBirdAppearanceMax = 76;

        // 25 naughthyBird
        private const int NaughtyBirdAppearanceMin = 77;
        private const int NaughtyBirdAppearanceMax = 100;

        public Bird Get(int left, int top)
        {
            int number = rand.Next(0, Count + 1);

            if (SkinyBirdAppearanceMin <= number && number <= SkinyBirdAppearanceMax)
            {
                var skinyBird = new SkinyBirdFactory();
                return skinyBird.Get(left, top);
            }
            else if (AngryBirdAppearanceMin <= number && number <= AngryBirdAppearanceMax)
            {
                var angryBird = new AngryBirdFactory();
                return angryBird.Get(left, top);
            }
            else if (MuscleBirdAppearanceMin <= number && number <= MuscleBirdAppearanceMax)
            {
                var muscleBird = new MuscleBirdFactory();
                return muscleBird.Get(left, top);
            }
            else
            {
                var naughthyBird = new NaughtyBirdFactory();
                return naughthyBird.Get(left, top);
            }
        }
    }
}