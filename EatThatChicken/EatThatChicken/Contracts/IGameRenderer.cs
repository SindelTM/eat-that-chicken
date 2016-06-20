using EatThatChicken.GameObjects;
using EatThatChicken.Misc;
using System;

namespace EatThatChicken.Renderers
{
    public interface IGameRenderer
    {
        int ScreenWidth { get; }

        int ScreenHeight { get; }

        void Clear();

        void Draw(params GameObject[] gameObjects);

        event EventHandler<KeyDownEventArgs> UIAction;
    }
}
