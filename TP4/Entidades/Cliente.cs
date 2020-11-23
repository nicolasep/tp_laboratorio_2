using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {

        private int id;
        private string dni;
        /// <summary>
        /// Constructor cliente que inicializa todos los campos, de usa cuando se recuperan los clientes de la BD
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <param name="dni">dni del cliente</param>
        /// <param name="nombre">nombre del cliente</param>
        /// <param name="apellido">apellido del cliente</param>
        public Cliente(int id, string dni, string nombre, string apellido)
            : base(nombre,apellido)
        {
            this.Id = id;
            this.Dni = dni;
        }
        /// <summary>
        /// constructor para crear un cliente 
        /// </summary>
        /// <param name="dni">dni del cliente</param>
        /// <param name="nombre">nombre del cliente</param>
        /// <param name="apellido">apellido del cliente</param>
        public Cliente(string dni, string nombre, string apellido)
            : this(0,dni,nombre, apellido)
        {

        }
        /// <summary>
        /// propiedad que retorna o asiga el ID
        /// </summary>
        public int Id
        {
            get
            {
                
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// propiedad que retorna o asigna el DNI
        /// </summary>
        public string Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        /// <summary>
        /// publica los datos del cliente
        /// </summary>
        /// <returns>devuelve un string con los datos del cliente</returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Id} {base.Mostrar()} {this.Dni}");
            return sb.ToString();
        }
        /// <summary>
        /// hace publicos los datos del cliente
        /// </summary>
        /// <returns>devuelve un string con los datos del cliente</returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// ingresa el cliente en la base de datos
        /// </summary>
        /// <param name="cliente">cliente a dar de alta</param>
        /// <returns>devuelve true si lo guardo, false si no pudo</returns>
        public bool IngresarCliente(Cliente cliente)
        {
            return ClientesDAO.Insertar(cliente);
        }

    }
}
