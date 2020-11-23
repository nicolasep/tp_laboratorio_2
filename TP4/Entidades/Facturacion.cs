using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades
{
    public static class Facturacion
    {

        /// <summary>
        /// verifica si el archo existe
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        private static bool FileExists(string ruta)
        {
            if(File.Exists(ruta))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// devuelve el directorio a usar
        /// </summary>
        private static string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }
        /// <summary>
        /// genera la factura y la guarda en un archo de texto en escritorio con el nombre de la fecha
        /// </summary>
        /// <param name="texto">texto de la factura</param>
        public static void GuardarFactura(string texto)
        {

            StreamWriter streamWriter = null;
            try
            {
                
                string rutaCompleta =  ".\\" + "factura.txt";
                streamWriter = new StreamWriter(rutaCompleta,false);
                streamWriter.WriteLine(texto);
            }
            catch(Exception ex)
            {
                throw new ArchivoInexistenteExcepcion(ex.Message);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }

            }

        }
        

    }  
}

