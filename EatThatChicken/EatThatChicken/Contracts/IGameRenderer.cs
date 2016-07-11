namespace EatThatChicken.Contracts
{
    using System;
    using System.Collections.Generic;
    using EatThatChicken.Common.Events;

    public interface IGameRenderer
    {
        int ScreenWidth { get; }

        int ScreenHeight { get; }

        void UpdateScoreOnRenderer(IHunter hunter);

        void Clear();

        void Draw(IEnumerable<IGameObject> gameObjects);

       // bool IsInRange(Position position);

        event EventHandler<KeyDownEventArgs> UIAction;

        void EndGame(int points);
    }
}
