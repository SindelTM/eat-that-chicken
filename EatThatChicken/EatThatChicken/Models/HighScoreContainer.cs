namespace EatThatChicken.Models
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class HighScoreContainer
    {
        private readonly List<IRecordable> records;

        public HighScoreContainer()
        {
            this.records = new List<IRecordable>();
        }

        public void Add(IRecordable record)
        {
            Validator.CheckIsNull(record);

            records.Add(record);
        }

        public List<IRecordable> GetRecords()
        {
            return new List<IRecordable>(records);
        }
    }
}
