using EatThatChicken.Common;
using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects.GameItems
{
    using Enumerations;

    public abstract class Item : GameObject, IAffectableGameObject
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Item(Size bounds, Position position, int speed) 
            : base(bounds, position, new MoveAction(Left, Top, speed)) { }

        public int PointAffect { get; set; }

        public virtual void AffectHunter(IHunter hunter)
        {
            hunter.Points += this.PointAffect;
        }
    }
}
