using EatThatChicken.Common;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Contracts
{
    using System;
    using GameObjects;
    using Misc;

    public interface IGameRenderer
    {
        int ScreenWidth { get; }

        int ScreenHeight { get; }

        void UpdateScore(Hunter hunter);

        void Clear();

        void Draw(params IGameObject[] gameObjects);

        bool IsInRange(Position position);

        event EventHandler<KeyDownEventArgs> UIAction;
    }
}
