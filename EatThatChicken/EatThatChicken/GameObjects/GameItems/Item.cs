namespace EatThatChicken.GameObjects.GameItems
{
    using Contracts;
    using Enumerations;

    public abstract class Item : GameObject, IScorable
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Item(uint score, Size bounds, Position position, int speed) 
            : base(bounds, position, new MoveAction(Left, Top, speed))
        {
            this.Score = score;
        }

        public uint Score { get; }
    }
}
