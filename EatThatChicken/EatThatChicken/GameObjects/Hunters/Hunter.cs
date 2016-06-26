using System;
using EatThatChicken.Contracts;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Hunters
{
    public class Hunter : GameObject, IHunter
    {
        public Hunter(Size bounds, Position position)
            : base(bounds, position, new MoveAction()) { }

        public void MoveLeft()
        {
            this.Move();
        }

        public void MoveRight()
        {
            this.Move();
        }
    }
}
