namespace EatThatChicken.Misc
{
    using EatThatChicken.GameObjects;

    public class SimpleCollisionDetector : ICollisionDetector
    {
        protected struct GameObjectBounds
        {
            public GameObjectBounds(Position topLeft, Position bottomRight)
                : this(topLeft.Left, topLeft.Top, bottomRight.Left, bottomRight.Top)
            {
            }

            public GameObjectBounds(int left, int top, int right, int bottom)
                : this()
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public int Left { get; set; }

            public int Right { get; set; }

            public int Top { get; set; }

            public int Bottom { get; set; }
        }

        public virtual bool AreCollided(GameObject firstGameObject, GameObject secondGameObject)
        {
            GameObjectBounds firstGameOnjectBounds = this.GetObjectBounds(firstGameObject);

            GameObjectBounds secondGameObjectBounds = this.GetObjectBounds(secondGameObject);

            bool shouldDie = this.SimpleCollision(firstGameOnjectBounds, secondGameObjectBounds);
            return shouldDie;
        }

        protected GameObjectBounds GetObjectBounds(GameObject gameObject)
        {
            int gameObjectLeft = gameObject.Position.Left;
            int gameObjectRight = gameObject.Position.Left + gameObject.Bounds.Width;
            int gameObjectTop = gameObject.Position.Top;
            int gameObjectBottom = gameObject.Position.Top + gameObject.Bounds.Height;
            GameObjectBounds gameObjectBounds = new GameObjectBounds(gameObjectLeft, gameObjectTop, gameObjectRight, gameObjectBottom);
            return gameObjectBounds;
        }

        private bool SimpleCollision(GameObjectBounds firstGameObjectBounds, GameObjectBounds secondGameObjectBounds)
        {
            return ((firstGameObjectBounds.Top <= secondGameObjectBounds.Top && secondGameObjectBounds.Top <= firstGameObjectBounds.Bottom) || (firstGameObjectBounds.Top <= secondGameObjectBounds.Bottom && secondGameObjectBounds.Bottom <= firstGameObjectBounds.Bottom)) &&
                   ((firstGameObjectBounds.Left <= secondGameObjectBounds.Left && secondGameObjectBounds.Left <= firstGameObjectBounds.Right) || (firstGameObjectBounds.Left <= secondGameObjectBounds.Right && secondGameObjectBounds.Right <= firstGameObjectBounds.Right));
        }
    }
}
