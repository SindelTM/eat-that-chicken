namespace EatThatChicken.Contracts
{
    public interface IAffectableGameObject : IGameObject
    {
        int PointAffect { get; }

        void AffectHunter(IHunter hunter);
    }
}
