using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects
{
    public abstract class GameObject : IGameObject
    {
         protected readonly int moveSpeed;
         protected readonly int moveTop;
         protected int moveLeft;

        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position) 
            : this()
        {
            this.Bounds = bounds;
            this.Position = position;
        }

        public Size Bounds { get; set; }
        public Position Position { get; set; }
        public virtual bool IsAlive { get; set; }
        public int MoveSpeed { get; set; }
        public int MoveTop { get; set; }
        public int MoveLeft { get; set; }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Move()
        {
            int left = this.Position.Left - (this.MoveLeft * this.MoveSpeed);
            int top = this.Position.Top - (this.MoveTop * this.MoveSpeed);

            this.Position = new Position(left, top);
        }
    }
}