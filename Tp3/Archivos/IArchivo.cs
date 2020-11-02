using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Formato de metodo para guardar
        /// </summary>
        /// <param name="archivo">nombre completo del archivo donde se va a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>devuelve true si pudo guardar, false si no</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Formato de metodo para leer un archivo
        /// </summary>
        /// <param name="archivo">nombre completo del archivo de donde se va a cargar los datos</param>
        /// <param name="datos">string en cual se van a cargar los datos</param>
        /// <returns>devuelve true si puedo leer, false si no</returns>
        bool Leer(string archivo, out T datos);
        
    }
}
