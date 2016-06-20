namespace EatThatChicken.GameObjects.Bullets
{
    using Contracts;

    public class Bullet : GameObject
    {
        public Bullet(Size bounds, Position position, bool isAlive)
            : base(bounds, position, isAlive) { }

        public void Move()
        {
            const int bulletSpeed = 40;
            int left = this.Position.Left;
            int top = this.Position.Top - bulletSpeed;

            this.Position = new Position(left, top);
        } 
    }
}