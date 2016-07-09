using EatThatChicken.Common;

namespace EatThatChicken.Contracts
{
    using GameObjects;

    public interface IGameObject : IUpdateable, IMoveable
    {
        Position Position { get; set; }

        bool IsAlive { get; set; }
    }
}
