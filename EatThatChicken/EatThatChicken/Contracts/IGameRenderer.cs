using System;
using System.Collections.Generic;
using EatThatChicken.GameObjects;
using EatThatChicken.Misc;

namespace EatThatChicken.Contracts
{
    public interface IGameRenderer
    {
        int ScreenWidth { get; }
        int ScreenHeight { get; }

        void Clear();
        void Draw(IEnumerable<IGameObject> gameObjects);
        bool IsInRange(Position position);

        event EventHandler<KeyDownEventArgs> UIAction;
    }
}