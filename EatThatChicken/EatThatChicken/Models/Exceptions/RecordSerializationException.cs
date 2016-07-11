namespace EatThatChicken.Models.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    class RecordSerializationException : ApplicationException
    {
        private const string DefaultMessage = "Unable to serialize/deserialize record!";

        public RecordSerializationException() : base(DefaultMessage) { }

        public RecordSerializationException(string message) : base(message) { }

        public RecordSerializationException(string message, Exception innerException) : base(message, innerException) { }

        public RecordSerializationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
