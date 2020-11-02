using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor con mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException():this("Alumno repetido")
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le pasa el mensaje pasado por parametro
        /// </summary>
        /// <param name="mensaje">mensaje del error</param>
        public AlumnoRepetidoException(string mensaje):base(mensaje)
        {

        }
    }
}
