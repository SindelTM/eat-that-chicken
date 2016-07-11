namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Common.Structs;

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
