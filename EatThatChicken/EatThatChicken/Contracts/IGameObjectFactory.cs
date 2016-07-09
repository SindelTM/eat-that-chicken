namespace EatThatChicken.Contracts
{
    public interface IGameObjectFactory<T>
        where T : IGameObject
    {
             T CreateBullet(int left, int top);
    }
}