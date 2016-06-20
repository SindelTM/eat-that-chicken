namespace EatThatChicken.GameObjects.Bullets
{
    using Contracts;

    public class Bullet : GameObject
    {
        public Bullet(Size bounds, Position position, bool isAlive)
            : base(bounds, position, isAlive) { }
    }
}