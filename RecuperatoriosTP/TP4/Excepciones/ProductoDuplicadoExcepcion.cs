using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class ProductoDuplicadoExcepcion : Exception
    {
        public ProductoDuplicadoExcepcion():this("El producto ya se encuentra ingresado")
        {
        }

        public ProductoDuplicadoExcepcion(string message) : this(message,null)
        {
        }

        public ProductoDuplicadoExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}