using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor con mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException():this("La nacionalidad no se condice con el numero de DNI")
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le pasa el mensaje pasado por parametro
        /// </summary>
        /// <param name="mensaje">mensaje a guardar</param>
        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {

        }
    }

}
