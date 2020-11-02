using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos pasados por parametros en un archivo de texto
        /// </summary>
        /// <param name="archivo">nombre completo del archivo donde se va a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>Devuevle true si pudo guardar los datos o un excepcion si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            bool guardo = false;
            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.WriteLine(datos);
                guardo = true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException("El archivo no se pudo guardar");
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
            return guardo;
        }
        /// <summary>
        /// Lee un archivo de texto y lo devuelve en un string parasado como parametro
        /// </summary>
        /// <param name="archivo">nombre completo del archivo a leer</param>
        /// <param name="datos">string donde se van a retornar los datos leidos</param>
        /// <returns>devuelve true si pudo leer el archo, false si no pudo leerlo</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            bool pudoLeer = false;
            string cadena;
            try
            {
                streamReader = new StreamReader(archivo);
                string texto = string.Empty;

                while((cadena = streamReader.ReadLine())!= null)
                {
                    texto += cadena + "\n";
                }
                datos = texto;
                pudoLeer = true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException("El archivo no se pudo leer");
            }
            finally
            {
                if(streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return pudoLeer;
        }
    }
}
