namespace EatThatChicken.GameObjects
{
    using Contracts;
    using Common;

    public abstract class GameObject : IGameObject
    {
        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position, MoveAction moveAction)
            : this()
        {
            this.Bounds = bounds;
            this.Position = position;
            this.MoveAction = moveAction;
        }

        protected MoveAction MoveAction { get; }

        public Size Bounds { get; set; }

        public Position Position { get; set; }

        public virtual bool IsAlive { get; set; }

        public int PointAffect { get; set; }
        
        public virtual void Move()
        {
            int left = this.Position.Left - ((int)this.MoveAction.Left * this.MoveAction.Speed);
            int top = this.Position.Top - ((int)this.MoveAction.Top * this.MoveAction.Speed);

            this.Position = new Position(left, top);
        }
    }
}