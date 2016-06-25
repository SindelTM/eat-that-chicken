namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleBird: Bird
    {
        private const int MuscleBirdDefaultHealth = 5;

        public MuscleBird()
            :base(MuscleBirdDefaultHealth)
        {
            this.MoveSpeed = 4;
            this.MoveTop = 0;
            this.MoveLeft = 1;
        }
    }
}
