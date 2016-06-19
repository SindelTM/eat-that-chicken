namespace EatThatChicken.Contracts
{
    using GameObjects;

    public interface ICollidable
    {
        Size Bounds { get; set; }
    }
}
