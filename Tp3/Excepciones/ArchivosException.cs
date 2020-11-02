using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor con mensaje por defecto
        /// </summary>
        public ArchivosException():this("Error en el archivo")
        {

        }
        /// <summary>
        /// Constructor que lleama a la base y le pasa el mensaje a almacenar
        /// </summary>
        /// <param name="mensaje">mensaje de error</param>
        public ArchivosException(string mensaje):base(mensaje)
        {

        }
        /// <summary>
        /// Constructor que llama a la base y le pasa un mensaje predeterminado a guardar y la excepcion
        /// </summary>
        /// <param name="innerException">excepcion</param>
        public ArchivosException(Exception innerException):base("Error en el archivo",innerException)
        {

        }
    }
}
