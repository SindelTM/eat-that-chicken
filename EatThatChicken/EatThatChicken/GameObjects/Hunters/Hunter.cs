using EatThatChicken.Contracts;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.Hunters
{
    public class Hunter : GameObject, IHunter
    {
        public Hunter(Size bounds, Position position)
            : base(bounds, position, new MoveAction(15)) { }

        public void MoveLeft()
        {
            int left = this.Position.Left - ((int)MoveType.Incremental * this.moveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }

        public void MoveRight()
        {
            int left = this.Position.Left - ((int)MoveType.Decremental * this.moveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }
    }
}
