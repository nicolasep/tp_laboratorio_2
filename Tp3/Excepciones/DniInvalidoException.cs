using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        /// <summary>
        /// Constructor con mensaje por defecto
        /// </summary>
        public DniInvalidoException():this("Dni Invalido")
        {

        }
        /// <summary>
        /// Constructor con mensaje por defecto que le pasa a la base junto con la cola de excepciones
        /// </summary>
        /// <param name="e">excepcion a guardar</param>
        public DniInvalidoException(Exception e):this("Dni Invalido",e)
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le carga el mensaje pasado por parametro
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje):base(mensaje)
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le pasa el mensaje y la excepcion
        /// </summary>
        /// <param name="mensaje">mensaje a guardar</param>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(string mensaje, Exception e):base(mensaje,e)
        {

        }
    }
}
