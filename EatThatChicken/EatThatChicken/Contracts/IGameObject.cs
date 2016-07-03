namespace EatThatChicken.Contracts
{
    using GameObjects;
    using System.Windows.Controls;
    public interface IGameObject : IUpdateable, IMoveable, ICollidable
    {
        Position Position { get; set; }

        bool IsAlive { get; set; }

        void Draw(Canvas playgroundCanvas);
    }
}
