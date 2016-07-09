using System.Collections.Generic;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Misc
{
    using EatThatChicken.GameObjects;

    public interface ICollisionDetector
    {
        bool AreCollided(GameObject firstGameObject, GameObject secondGameObject);

        void HandleCollision(Hunter hunter, List<GameObject> gameObjects);
    }
}
