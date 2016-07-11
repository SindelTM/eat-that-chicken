namespace EatThatChicken.Contracts
{
    using System.Collections.Generic;

    public interface ICollisionDetector
    {
        void HandleCollisions(IList<IBullet> bullets, IList<IBird> birds, IHunter hunter,
            IList<IGameObject> gameObjects);

        bool IsHunterColliding(IHunter hunter, IList<IBird> birds);
    }
}
