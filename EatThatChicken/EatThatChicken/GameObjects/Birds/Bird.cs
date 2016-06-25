using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects.Birds
{
    public abstract class Bird : GameObject, IMoveable
    {
        protected Bird(int health) 
            : base()
        {
            this.Health = health;
        }

        protected int Health { get; set; }

        public override void Move()
        {
            //   int left = this.Position.Left - (this.MoveLeft * this.MoveSpeed);
            //   int top = this.Position.Top - (this.MoveTop * this.MoveSpeed);
               int left = this.Position.Left - (this.MoveLeft * this.MoveSpeed);
               int top = this.Position.Top - (this.MoveTop * this.MoveSpeed);
            this.Position = new Position(left, top);
        }



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
