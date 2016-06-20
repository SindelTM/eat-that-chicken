namespace EatThatChicken.Contracts
{
    using EatThatChicken.GameObjects;

    public interface IGameObjectFactory<T>
        where T : IGameObject
    {
             T Get(int left, int top);
    }
}