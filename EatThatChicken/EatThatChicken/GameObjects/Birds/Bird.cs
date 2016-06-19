namespace EatThatChicken.GameObjects.Birds
{
    using Contracts;

    public class Bird : GameObject, IMoveable, IUpdateable
    {
        public Bird(Size bounds, Position position, bool isAlive, int points)
            :base(bounds, position, isAlive)
        {
            this.Points = points;
        }

        public int Points { get; set; }
    }
}
