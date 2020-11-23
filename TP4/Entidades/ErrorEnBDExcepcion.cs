using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class ErrorEnBDExcepcion : Exception
    {
        public ErrorEnBDExcepcion()
        {
        }

        public ErrorEnBDExcepcion(string message) : base(message)
        {
        }

        public ErrorEnBDExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorEnBDExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}