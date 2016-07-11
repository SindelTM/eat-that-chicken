namespace EatThatChicken.Models.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using Common;
    using Contracts;
    using Exceptions;

    public class RecordSerializer : ISerializer<HighScoreContainer>
    {
        private readonly IFormatter formatter;
        private readonly string fileName;

        public RecordSerializer(IFormatter formatter, string fileName)
        {
            Validator.CheckIsNull(formatter);
            this.formatter = formatter;

            Validator.CheckIfStringIsNullOrEmpty(fileName);
            this.fileName = fileName;
        }

        public HighScoreContainer Deserialize()
        {
            HighScoreContainer result;
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    result = (HighScoreContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                throw new RecordSerializationException("Unable to deserialize records from file");
            }

            return result;
        }

        public void Serialize(HighScoreContainer obj)
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(stream, obj);
                }
            }
            catch (Exception)
            {
                throw new RecordSerializationException("Unable to serialize records from file");
            }
        }
    }
}
