using System;
using EatThatChicken.Common.Enumerations;

namespace EatThatChicken.Common.Events
{
    public class KeyDownEventArgs : EventArgs
    {
        public GameAction Action { get; set; }

        public KeyDownEventArgs(GameAction action)
        {
            this.Action = action;
        }
    }
}
