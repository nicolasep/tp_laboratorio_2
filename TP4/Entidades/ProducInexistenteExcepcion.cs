using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class ProducInexistenteExcepcion : Exception
    {
        public ProducInexistenteExcepcion():this("No se encontro el producto")
        {
        }

        public ProducInexistenteExcepcion(string message) : this(message,null)
        {
        }

        public ProducInexistenteExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}