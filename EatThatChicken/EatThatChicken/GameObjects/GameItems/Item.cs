namespace EatThatChicken.GameObjects.GameItems
{
    using Enumerations;

    public abstract class Item : GameObject
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Item(Size bounds, Position position, int speed) 
            : base(bounds, position, new MoveAction(Left, Top, speed)) { }

        public int PointAffect { get; set; }
    }
}
