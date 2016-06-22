namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int AngryBirdDefaultHealth = 3; 

        public AngryBird()
            :base(AngryBirdDefaultHealth)
        {
        }
    }
}
