namespace EatThatChicken.GameObjects.Bullets
{
    using Contracts;

    public class Bullet : GameObject
    {

        public Bullet(Size bounds, Position position)
            : base(bounds, position)
        {
            this.MoveSpeed = 40;
            this.MoveTop = -1;
            this.MoveLeft = 0;
        }
        
    }
}