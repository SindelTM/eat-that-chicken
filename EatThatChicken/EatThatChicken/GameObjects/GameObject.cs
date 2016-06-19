using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        protected GameObject()
        {
            this.IsAlive = true;
        }

        protected GameObject(Size bounds, Position position, bool isAlive)
        {
            this.Bounds = bounds;
            this.Position = position;
            this.IsAlive = true;
        }

        public Size Bounds { get; set; }

        public Position Position { get; set; }

        public virtual bool IsAlive { get; set; }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
        
        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
