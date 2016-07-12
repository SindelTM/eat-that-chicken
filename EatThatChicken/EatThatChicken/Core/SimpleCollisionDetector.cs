namespace EatThatChicken.Core
{
    using System.Collections.Generic;
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Contracts;
    using EatThatChicken.GameObjects.Hunters;

    public class SimpleCollisionDetector : ICollisionDetector
    {
        public void HandleCollisions(IList<IBullet> bullets, IList<IBird> birds, IHunter hunter, IList<IGameObject> gameObjects)
        {
            this.HandleCollisionBetweenBulletsAndObjects(bullets, birds, hunter);
            this.HandleCollisionBetweenObjectsAndHunter(hunter, gameObjects);
        }

        public bool IsHunterColliding(IHunter hunter, IList<IBird> birds)
        {
            foreach (var bird in birds)
            {
                if (AreCollided(hunter, bird))
                {
                    bird.IsAlive = false;
                    bird.Health = 0;
                    hunter.NumberOfLifes--;
                    return true;
                }
            }
            return false;
        }

        //IList<IAffectableGameObject>
        private void HandleCollisionBetweenObjectsAndHunter(IHunter hunter, IList<IGameObject> gameObjects)
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

        private void HandleCollisionBetweenBulletsAndObjects(IList<IBullet> bullets, IList<IBird> birds, IHunter hunter)
        {
            foreach (var bullet in bullets)
            {
                foreach (var bird in birds)
                {
                    if (AreCollided(bird, bullet))
                    {
                        bullet.IsAlive = false;
                        bird.IsAlive = false;
                        bird.AffectHunterPointsByBullet(hunter);
                        break;
                    }
                }
            }
        }

        private bool AreCollided(IGameObject firstGameObject, IGameObject secondGameObject)
        {
            GameObjectBounds firstGameOnjectBounds = this.GetObjectBounds(firstGameObject);

            GameObjectBounds secondGameObjectBounds = this.GetObjectBounds(secondGameObject);

            bool shouldDie = this.SimpleCollision(firstGameOnjectBounds, secondGameObjectBounds);
            return shouldDie;
        }

        private GameObjectBounds GetObjectBounds(IGameObject gameObject)
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
    }
}
