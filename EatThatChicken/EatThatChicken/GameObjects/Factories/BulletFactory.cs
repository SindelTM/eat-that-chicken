using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Bullets;

namespace EatThatChicken.GameObjects.Factories
{
    public class BulletFactory : IGameObjectFactory
    {
        const int bulletWidth = 10;
        const int bulletHeight = 30;
        public GameObject Get(int left, int top)
        {
            return new Bullet()
            {
                Position = new Position (left, top),
                Bounds = new Size (bulletWidth, bulletHeight)
            };
        }
    }
}