using System.Windows.Controls;
using EatThatChicken.Common;

namespace EatThatChicken.Contracts
{
    using GameObjects;

    public interface IGameObject : IMoveable
    {
        Position Position { get; set; }

        Size Bounds { get; set; }

        bool IsAlive { get; set; }

        int PointAffect { get; set; }

        void Draw(Canvas playgroundCanvas);
    }
}
