namespace EatThatChicken.GameObjects.Birds
{
    using Contracts;


    // TODO remove constructor when hunter is initialized correctly


    public abstract class Bird : GameObject
    {
        protected Bird(Size bounds, Position position, bool isAlive, int point) 
            : base(bounds, position, isAlive)
        {

        }
        protected Bird()
        {

        }
    }
}
