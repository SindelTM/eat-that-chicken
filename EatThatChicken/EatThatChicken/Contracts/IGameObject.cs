namespace EatThatChicken.Contracts
{
    using GameObjects;

    public interface IGameObject : IUpdateable, IMoveable, ICollidable
    {
        Position Position { get; set; }

        bool IsAlive { get; set; }
    }
}
