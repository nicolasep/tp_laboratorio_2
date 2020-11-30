using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class BackUpListaClientes<T>
    {
        public void Serializar(T objeto, string rutaCompleta)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                writer = new XmlTextWriter(rutaCompleta, Encoding.UTF8);
                
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        public T Deserealizar(string rutaCompleta)
        {
            using (XmlTextReader reader = new XmlTextReader(rutaCompleta))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
