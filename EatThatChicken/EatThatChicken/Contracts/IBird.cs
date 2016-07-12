namespace EatThatChicken.Contracts
{
    public interface IBird: IBulletAffectable, IAffectableGameObject
    {
        int Health { get; set; }
    }
}
