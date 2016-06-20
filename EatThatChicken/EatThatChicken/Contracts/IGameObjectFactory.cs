namespace EatThatChicken.Contracts
{
    using EatThatChicken.GameObjects;

    public interface IGameObjectFactory
    {
             GameObject Get(int left, int top);
    }
}