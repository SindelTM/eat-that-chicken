using System.Collections.Generic;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Misc
{
    using EatThatChicken.GameObjects;

    public interface ICollisionDetector
    {
        bool AreCollided(IGameObject firstGameObject, IGameObject secondGameObject);

        void KillIfColliding(IList<IGameObject> bullets, IList<IGameObject> birds);

        void HandleCollision(Hunter hunter, IEnumerable<IGameObject> gameObjects);
    }
}
