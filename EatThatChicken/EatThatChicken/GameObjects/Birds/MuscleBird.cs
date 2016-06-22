namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleBird: Bird
    {
        private const int MuscleBirdDefaultHealth = 5;

        public MuscleBird()
            :base(MuscleBirdDefaultHealth)
        {
            this.MoveSpeed = 20;
            this.MoveTop = -1;
            this.MoveLeft = 0;
        }
    }
}
