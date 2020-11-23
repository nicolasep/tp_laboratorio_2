using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class ArchivoInexistenteExcepcion : Exception
    {
        public ArchivoInexistenteExcepcion():this("No se encontro el archivo")
        {
        }

        public ArchivoInexistenteExcepcion(string message) : this(message,null)
        {
        }

        public ArchivoInexistenteExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}