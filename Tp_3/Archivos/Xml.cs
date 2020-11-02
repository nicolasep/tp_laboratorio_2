using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{

    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos serializados en un archivo xml
        /// </summary>
        /// <param name="archivo">nombre completo del archivo donde se va a guardar</param>
        /// <param name="datos">datos a guardar en el archivo</param>
        /// <returns>devuelve true si pudo guardar, una excepcion si no pudo</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            bool guardo = false;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                guardo = true;
            }
            catch(Exception)
            {
                throw new ArchivosException("Error al serializar");
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
            }
            return guardo;
        }
        /// <summary>
        /// Lee un archivo, lo deseraliza y lo carga
        /// </summary>
        /// <param name="archivo">nombre completo del archivo</param>
        /// <param name="datos">tipo de dato en el que se devuelve</param>
        /// <returns>Devuelve true si puedo leer el archivo, false si no pudo</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool pudoLeer = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
                    pudoLeer = true;
                }
            }
            catch(Exception)
            {
                throw new ArchivosException("No se pudo deseruializar");
            }
            
            return pudoLeer;
        }
    }
}
