namespace EatThatChicken.GameObjects.Birds
{
    using Common;
    using Contracts;
    using EatThatChicken.Common.Enumerations;
    using EatThatChicken.Common.Structs;

    public abstract class Bird : GameObject, IBird
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;

        protected Bird(int health, int pointAffect, Size bounds, Position position, int speed)
            : base(bounds, position, new MoveAction(Left, Top, speed))
        {
            this.Health = health;
            this.PointAffect = pointAffect;
        }

        public int Health { get;  set; }

        public int PointAffect { get; private set; }

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

        public void AffectHunter(IHunter hunter)
        {
            if (hunter.NumberOfLifes >= 1)
            {
                hunter.NumberOfLifes--;
            }
        }

        public void AffectHunterPointsByBullet(IHunter hunter)
        {
            hunter.Points += this.PointAffect;
        }
    }
}
