namespace EatThatChicken.GameObjects.Birds
{
    using Contracts;
    using Enumerations;
    public abstract class Bird : GameObject, IMoveable, IScorable
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Bird(int health, uint score, Size bounds, Position position, int speed)
            : base(bounds, position, new MoveAction(Left, Top, speed))
        {
            this.Health = health;
            this.Score = score;
        }

        public uint Score { get; }

        protected int Health { get; set; }

        public override bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
            set
            {
                if (!value)
                {
                    --this.Health;
                }
            }
        }
    }
}
