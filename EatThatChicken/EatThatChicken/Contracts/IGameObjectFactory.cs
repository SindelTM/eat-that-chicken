namespace EatThatChicken.Contracts
{
    public interface IGameObjectFactory<T>
        where T : IGameObject
    {
             T Get(int left, int top);
    }
}