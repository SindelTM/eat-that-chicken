namespace EatThatChicken.Contracts
{
    public interface ISerializer<T>
    {
        void Serialize(T obj);

        T Deserialize();
    }
}
