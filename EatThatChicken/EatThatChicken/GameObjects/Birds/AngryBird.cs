using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int AngryBirdDefaulScore = 3;

        private const int AngryBirdDefaultHealth = 3;

        public AngryBird(Size bounds, Position position, int speed)
            : base(AngryBirdDefaultHealth, AngryBirdDefaulScore, bounds, position, speed)
        {
        }
    }
}
