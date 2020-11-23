using System;
using System.Runtime.Serialization;

namespace Entidades
{
    
    public class CantidadNoDisponibleExcepcion : Exception
    {
        public CantidadNoDisponibleExcepcion():this("La cantidad pretendida supera el stock disponible")
        {
        }

        public CantidadNoDisponibleExcepcion(string message) : this(message,null)
        {
        }

        public CantidadNoDisponibleExcepcion(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}