using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Bullets;

namespace EatThatChicken.Factories
{
    public class BulletFactory : IGameObjectFactory<Bullet>
    {
        const int bulletWidth = 10;
        const int bulletHeight = 30;

        public Bullet Get(int left, int top)
        {
            Position position = new Position(left - (bulletWidth / 2), top);
            Size bounds = new Size(bulletWidth, bulletHeight);

            return new Bullet(bounds, position);
        }
    }
}