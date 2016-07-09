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

        public int Score { get; }

        public Player(DateTime date, string name, int score)
        {
            Validator.CheckIsNull(date);
            this.Date = date;

            Validator.CheckIfStringIsNullOrEmpty(name);
            this.Name = name;

            this.Score = score;
        }
    }
}
