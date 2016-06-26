using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        protected readonly MoveAction moveAction;

        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position, MoveAction moveAction)
            : this()
        {
            this.Bounds = bounds;
            this.Position = position;
            this.moveAction = moveAction;
        }

        public MoveAction MoveAction { get; }

        public Size Bounds { get; set; }
        public Position Position { get; set; }
        public virtual bool IsAlive { get; set; }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            int left = this.Position.Left - ((int)this.moveAction.Left * this.moveAction.Speed);
            int top = this.Position.Top - ((int)this.moveAction.Top * this.moveAction.Speed);

            this.Position = new Position(left, top);
        }
    }
}