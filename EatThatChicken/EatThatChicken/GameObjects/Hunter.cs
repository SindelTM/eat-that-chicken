namespace EatThatChicken
{
    using EatThatChicken.GameObjects;

    public class Hunter : GameObject
    {
        public Hunter(Size bounds, Position position)
            : base(bounds, position)
        {
            this.MoveSpeed = 15;
            this.MoveTop = 0;
            this.MoveLeft = 0;
        }
    }
}
