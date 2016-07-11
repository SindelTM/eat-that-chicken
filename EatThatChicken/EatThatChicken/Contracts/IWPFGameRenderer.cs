using EatThatChicken.Common.Events;

namespace EatThatChicken.Contracts
{
    using System;

    interface IWPFGameRenderer : IGameRenderer
    {
        event EventHandler<EndGameEventArgs> EndGameAction;
    }
}
