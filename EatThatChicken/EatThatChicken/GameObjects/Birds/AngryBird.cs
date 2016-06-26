namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: Bird
    {
        private const int AngryBirdDefaultHealth = 3; 

        public AngryBird()
            :base(AngryBirdDefaultHealth)
        {
            this.MoveSpeed = 6;
            this.MoveTop = -1;
            this.MoveLeft = 0;
        }
    }
}
