namespace EatThatChicken.GameObjects.Birds
{
    public class SkinyBird: Bird
    {
        private const int SkinnyBirdHealth = 1;

        public SkinyBird()
            :base(SkinnyBirdHealth)
        {
            this.MoveSpeed = 8;
            this.MoveTop = -1;
            this.MoveLeft = 0;
        }
    }
}
