using System.Collections.Generic;
using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Misc
{
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

        public virtual bool AreCollided(IGameObject firstGameObject, IGameObject secondGameObject)
        {
            GameObjectBounds firstGameOnjectBounds = this.GetObjectBounds(firstGameObject);

            GameObjectBounds secondGameObjectBounds = this.GetObjectBounds(secondGameObject);

            bool shouldDie = this.SimpleCollision(firstGameOnjectBounds, secondGameObjectBounds);
            return shouldDie;
        }

        protected GameObjectBounds GetObjectBounds(IGameObject gameObject)
        {
            int gameObjectLeft = gameObject.Position.Left;
            int gameObjectRight = gameObject.Position.Left + gameObject.Bounds.Width;
            int gameObjectTop = gameObject.Position.Top + 50;
            int gameObjectBottom = gameObject.Position.Top + gameObject.Bounds.Height;
            GameObjectBounds gameObjectBounds = new GameObjectBounds(gameObjectLeft, gameObjectTop, gameObjectRight, gameObjectBottom);
            return gameObjectBounds;
        }

        private bool SimpleCollision(GameObjectBounds firstGameObjectBounds, GameObjectBounds secondGameObjectBounds)
        {
            return
                ((firstGameObjectBounds.Top <= secondGameObjectBounds.Top && secondGameObjectBounds.Top <= firstGameObjectBounds.Bottom) ||
                (firstGameObjectBounds.Top <= secondGameObjectBounds.Bottom && secondGameObjectBounds.Bottom <= firstGameObjectBounds.Bottom)) &&
                ((firstGameObjectBounds.Left <= secondGameObjectBounds.Left && secondGameObjectBounds.Left <= firstGameObjectBounds.Right) ||
                (firstGameObjectBounds.Left <= secondGameObjectBounds.Right && secondGameObjectBounds.Right <= firstGameObjectBounds.Right));
        }

                                                    //IList<IAffectableGameObject>
        public void HandleCollision(Hunter hunter, IEnumerable<IGameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                if (this.AreCollided(hunter, gameObject) && !(gameObject is Hunter))
                {
                    var objectAsAffectableGameObject = gameObject as IAffectableGameObject;

                    //null propagation => C# 6.0
                    objectAsAffectableGameObject?.AffectHunter(hunter);

                    gameObject.IsAlive = false;
                }
            }
        }
    }
}
