namespace EatThatChicken.Misc
{
    using EatThatChicken.GameObjects;

    public interface ICollisionDetector
    {
        bool AreCollided(GameObject firstGameObject, GameObject secondGameObject);
    }
}
