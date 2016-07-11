namespace EatThatChicken.Contracts
{
    using EatThatChicken.Common.Structs;

    public interface IGameObject : IMoveable
    {
        Position Position { get; set; }

        Size Bounds { get; set; }

        bool IsAlive { get; set; }
    }
}
