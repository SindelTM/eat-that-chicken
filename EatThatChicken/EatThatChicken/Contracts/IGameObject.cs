using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Common.Structs;

namespace EatThatChicken.Contracts
{
    using GameObjects;

    public interface IGameObject : IMoveable
    {
        Position Position { get; set; }

        Size Bounds { get; set; }

        bool IsAlive { get; set; }
    }
}
