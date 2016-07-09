namespace EatThatChicken.Models
{
    using Common;
    using Contracts;
    using System;

    [Serializable]
    public class Player : IRecordable
    {
        public DateTime Date { get; }

        public string Name { get; }

        public uint Score { get; }

        public Player(DateTime date, string name, uint score)
        {
            Validator.CheckIsNull(date);
            this.Date = date;

            Validator.CheckIfStringIsNullOrEmpty(name);
            this.Name = name;

            this.Score = score;
        }
    }
}
