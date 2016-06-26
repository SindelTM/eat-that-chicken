namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Contracts;

    public abstract class Bird : GameObject, IMoveable
    {
        protected Bird(int health, Size bounds, Position position, MoveAction moveAction) 
            : base(bounds, position, moveAction)
        {
            this.Health = health;
        }

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
