namespace EatThatChicken.GameObjects.GameItems
{
    using EatThatChicken.Common;
    using EatThatChicken.Common.Enumerations;
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Contracts;

    public abstract class Item : GameObject, IAffectableGameObject
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Item(Size bounds, Position position, int speed, int pointAffect)
            : base(bounds, position, new MoveAction(Left, Top, speed))
        {
            this.PointAffect = pointAffect;
        }

        public int PointAffect { get; private set; }

        public virtual void AffectHunter(IHunter hunter)
        {
            hunter.Points += this.PointAffect;
        }
    }
}
