using System.Collections.Generic;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Misc
{
    using EatThatChicken.GameObjects;

    public interface ICollisionDetector
    {
        bool AreCollided(IGameObject firstGameObject, IGameObject secondGameObject);

        void HandleCollision(Hunter hunter, IEnumerable<IGameObject> gameObjects);
    }
}
