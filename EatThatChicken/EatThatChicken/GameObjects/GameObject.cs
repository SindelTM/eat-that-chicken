namespace EatThatChicken.GameObjects
{
    public abstract class GameObject
    {
        public GameObject()
        {
            this.IsAlive = true;
        }

        Size Bounds { get; set; }

        Position Position { get; set; }

        public virtual bool IsAlive { get; set; }
    }
}
