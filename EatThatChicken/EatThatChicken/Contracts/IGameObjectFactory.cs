namespace EatThatChicken.Contracts
{
    public interface IGameObjectFactory<T>
        where T : IGameObject
    {
             T Create(int left, int top);
    }
}