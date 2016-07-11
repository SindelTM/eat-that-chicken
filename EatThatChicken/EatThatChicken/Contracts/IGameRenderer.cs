using EatThatChicken.Common;
using EatThatChicken.Common.Events;
using EatThatChicken.Common.Structs;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Contracts
{
    using System;
    using GameObjects;
    using System.Collections.Generic;
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
