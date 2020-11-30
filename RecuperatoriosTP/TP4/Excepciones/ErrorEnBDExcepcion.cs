using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class ErrorEnBDExcepcion : Exception
    {
        public ErrorEnBDExcepcion():this("Error en la base de datos")
        {
        }

        public ErrorEnBDExcepcion(string message) : this(message,null)
        {
        }

        public ErrorEnBDExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}