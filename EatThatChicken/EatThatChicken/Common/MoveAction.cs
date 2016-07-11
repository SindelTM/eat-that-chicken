namespace EatThatChicken.Common
{
    using EatThatChicken.Common.Enumerations;

    public class MoveAction
    {
        public MoveType Left { get; }

        public MoveType Top { get; }

        public int Speed { get; }

        public MoveAction() : this(MoveType.None, MoveType.None, 0) { }

        public MoveAction(int speed) : this(MoveType.None, MoveType.None, speed) { }

        public MoveAction(MoveType left, MoveType top, int speed)
        {
            this.Left = left;
            this.Top = top;
            this.Speed = speed;
        }
    }
}
