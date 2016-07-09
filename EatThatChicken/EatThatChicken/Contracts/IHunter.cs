namespace EatThatChicken.Contracts
{
    public interface IHunter : IGameObject
    {
        void MoveLeft();

        void MoveRight();

        int Points { get; set; }

        uint NumberOfLifes { get; set; }
    }
}
