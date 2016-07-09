using EatThatChicken.Common;

namespace EatThatChicken.Contracts
{
    using System;
    using GameObjects;
    using Misc;

    public interface IGameRenderer
    {
        int ScreenWidth { get; }

        int ScreenHeight { get; }

        void UpdateScore(uint score);

        void Clear();

        void Draw(params GameObject[] gameObjects);

        bool IsInRange(Position position);

        event EventHandler<KeyDownEventArgs> UIAction;
    }
}
