using System;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Service.Implementation
{
    [Serializable]
    internal class PersonNotFoundException : Exception
    {
        public PersonNotFoundException() : base ("Person not found!")
        {
        }

        public PersonNotFoundException(string message) : base(message)
        {
        }

        public PersonNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}