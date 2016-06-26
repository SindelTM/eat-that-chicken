namespace EatThatChicken.GameObjects.Birds
{
    using EatThatChicken.Contracts;

    public abstract class Bird : GameObject, IMoveable
    {
        protected Bird(int health) 
            : base()
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
