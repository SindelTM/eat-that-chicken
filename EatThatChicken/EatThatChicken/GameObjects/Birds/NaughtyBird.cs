using System.Windows.Controls;
using EatThatChicken.Common;

namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Enumerations;

    public class NaughtyBird : Bird
    {
        private const int NaughtyBirdDefaultHealth = 2;

        private const int NaughtyBirdDefaultScore = 2;

        public NaughtyBird(Size bounds, Position position, int speed)
            : base(NaughtyBirdDefaultHealth, NaughtyBirdDefaultScore, bounds, position, speed)
        {
        }
    }
}
