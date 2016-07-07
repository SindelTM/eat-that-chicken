namespace EatThatChicken.Contracts
{
    using System;

    public interface IRecordable : IScorable
    {
        string Name { get; }

        DateTime Date { get; }
    }
}
