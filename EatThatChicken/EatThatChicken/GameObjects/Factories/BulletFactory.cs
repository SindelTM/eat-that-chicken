using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Bullets;

namespace EatThatChicken.GameObjects.Factories
{
    public class BulletFactory : IGameObjectFactory<Bullet>
    {
        const int bulletWidth = 10;
        const int bulletHeight = 30;
        public Bullet Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(bulletWidth, bulletHeight);
            bool isAlive = true;

            return new Bullet(bounds, position, isAlive);
        }
    }
}