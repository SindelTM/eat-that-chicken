using EatThatChicken.GameObjects;
using System;

namespace EatThatChicken.Renderers
{
    public interface IGameRenderer
    {
        void Clear();

        void Draw(params GameObject[] gameObjects);

        event EventHandler UIAction;

        void UIActionHandler(object sender, EventArgs args);
    }
}
