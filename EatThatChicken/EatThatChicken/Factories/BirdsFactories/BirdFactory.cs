
namespace EatThatChicken.Factories.BirdsFactories
{
    using System;
    using Contracts;
    using GameObjects.Birds;

    public class BirdsFactory : IGameObjectFactory<Bird>
    {
        static readonly Random rand = new Random();
        private const int Count = 100;
        
        private const int SkinyBirdAppearanceMin = 0;
        private const int SkinyBirdAppearanceMax = 30;
        
        private const int AngryBirdAppearanceMin = 31;
        private const int AngryBirdAppearanceMax = 60;
        
        private const int MuscleBirdAppearanceMin = 61;
        private const int MuscleBirdAppearanceMax = 76;
        
        private const int NaughtyBirdAppearanceMin = 77;
        private const int NaughtyBirdAppearanceMax = 100;

        public Bird CreateBullet(int left, int top)
        {
            int number = rand.Next(0, Count + 1);

            if (SkinyBirdAppearanceMin <= number && number <= SkinyBirdAppearanceMax)
            {
                var skinyBird = new SkinyBirdFactory();
                return skinyBird.CreateBullet(left, top);
            }
            else if (AngryBirdAppearanceMin <= number && number <= AngryBirdAppearanceMax)
            {
                var angryBird = new AngryBirdFactory();
                return angryBird.CreateBullet(left, top);
            }
            else if (MuscleBirdAppearanceMin <= number && number <= MuscleBirdAppearanceMax)
            {
                var muscleBird = new MuscleBirdFactory();
                return muscleBird.CreateBullet(left, top);
            }
            else
            {
                var naughthyBird = new NaughtyBirdFactory();
                return naughthyBird.CreateBullet(left, top);
            }
        }
    }
}