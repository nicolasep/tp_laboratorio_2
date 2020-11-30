using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Cliente))]
    public class Clientes
    {
        

        private List<Cliente> listaClientes;
        private int ultimoIdAsignado;

        /// <summary>
        /// constructor sin paramtros que inicializa la lista
        /// </summary>
        public Clientes()
        {
            this.listaClientes = new List<Cliente>();
            this.ultimoIdAsignado = 0;
        }
        /// <summary>
        /// propiedad que asigna y devuelve la lista de clientes
        /// </summary>
        public List<Cliente> ListaClientes
        {
            get
            {
                return this.listaClientes;
            }
            set
            {
                this.listaClientes = value;
            }
        }
        /// <summary>
        /// propiedad que asigna y devuelve el ultimo id usado
        /// </summary>
        private int UltimoIdAsignado
        {
            get
            {
                return this.ultimoIdAsignado;
            }
            set
            {
                this.ultimoIdAsignado = value;
            }
        }
        /// <summary>
        /// agrega un cliente a la lista 
        /// </summary>
        /// <param name="c1">cliente a agregar</param>
        /// <returns>devuelve el cliente agregado con el Id asigando</returns>
        public Cliente AgregarCliente(Cliente c1)
        {
            if((this.ListaClientes.Count > 0 && this != c1) || this.ListaClientes.Count == 0)
            {
               
                    c1.Id = this.ultimoIdAsignado + 1;
                    this.listaClientes.Add(c1);
                    this.UltimoIdAsignado++;
                    this.Serializar();  
            }
            
            return c1;
        }
        /// <summary>
        /// verifica si se contiene al cliente
        /// </summary>
        /// <param name="lista">lista de clientes</param>
        /// <param name="c1">cliente a evaluar</param>
        /// <returns>devuelve true si el cliente se encuentra, false si no existe</returns>
        public static bool operator ==(Clientes lista, Cliente c1)
        {
            if(lista.ListaClientes.Count > 0)
            {
                foreach (Cliente c in lista.ListaClientes)
                {
                    if (!(c is null)  && c == c1)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        /// <summary>
        /// verifica si no se contiene al cliente
        /// </summary>
        /// <param name="lista">lista de clientes</param>
        /// <param name="c1">cliente a evaluar</param>
        /// <returns>devuelve false si el cliente se encuentra, true si no existe</returns>
        public static bool operator !=(Clientes lista, Cliente c1)
        {
            
            return !(lista == c1);
        }
        /// <summary>
        /// publica los datos del cliente
        /// </summary>
        /// <returns>devuelve un string con los datos del cliente</returns>
        public string MostrarListaClientes()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Cliente c in this.ListaClientes)
            {
                sb.Append(c.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// serializa la lista de clientes
        /// </summary>
        public void Serializar()
        {
            string rutaCompleta = ".\\clientes.xml";
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            try
            {
                writer = new XmlTextWriter(rutaCompleta, Encoding.UTF8);

                serializer = new XmlSerializer(typeof(Clientes));
                serializer.Serialize(writer, this);

            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// deserializa la lista de clientes
        /// </summary>
        /// <returns>devuelve una lista con los clientes serializados</returns>
        public List<Cliente> Deserealizar()
        {
            string rutaCompleta = ".\\clientes.xml";
            
            using (XmlTextReader reader = new XmlTextReader(rutaCompleta))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(Cliente));
                return (List<Cliente>)serializer.Deserialize(reader);
            }
        }
    }
}
