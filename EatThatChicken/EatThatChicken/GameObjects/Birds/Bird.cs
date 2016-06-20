namespace EatThatChicken.GameObjects.Birds
{
    using Contracts;


    // TODO remove constructor when hunter is initialized correctly


    public abstract class Bird : GameObject
    {
        public Bird(Size bounds, Position position, bool isAlive, int point) 
            : base(bounds, position, isAlive)
        {

        }
        public Bird()
        {

        }
    }
}
