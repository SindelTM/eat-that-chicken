namespace EatThatChicken.Models
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    [Serializable]
    public class HighScoreContainer
    {
        private readonly List<IRecordable> records;
        private const int MaxCount = 10;

        public HighScoreContainer()
        {
            this.records = new List<IRecordable>();
        }

        public void Add(IRecordable record)
        {
            Validator.CheckIsNull(record);

            if (this.records.Count == MaxCount)
            {
                IRecordable min = records.OrderBy(d => d.Score).ToList()[0];
                if (record.Score < min.Score)
                {
                    return;
                }
                this.records.Remove(min);
            }

            this.records.Add(record);
        }

        public List<IRecordable> GetRecords()
        {
            return new List<IRecordable>(this.records).OrderByDescending(d => d.Score).ToList();
        }
    }
}
