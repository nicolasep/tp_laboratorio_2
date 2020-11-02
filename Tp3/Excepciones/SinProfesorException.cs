using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor con mensaje por defecto
        /// </summary>
        public SinProfesorException():this("No hay profesor para esta clase")
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le pasa el mensaje pasado por parametro
        /// </summary>
        /// <param name="mensaje">mensaje de la excepcion</param>
        public SinProfesorException(string mensaje):base(mensaje)
        {

        }
    }
}
