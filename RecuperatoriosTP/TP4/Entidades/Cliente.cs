using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   
    public class Cliente
    {

        private int id;
        private string dni;
        private string nombre;
        private string apellido;

        public Cliente()
        {

        }
        /// <summary>
        /// Constructor cliente que inicializa todos los campos
        /// </summary>
        /// <param name="dni">dni del cliente</param>
        /// <param name="nombre">nombre del cliente</param>
        /// <param name="apellido">apellido del cliente</param>
        public Cliente( string dni, string nombre, string apellido) :this(0,dni,nombre,apellido)
        {

        }
        /// <summary>
        /// Constructor cliente que inicializa todos los campos
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <param name="dni">dni del cliente</param>
        /// <param name="nombre">nombre del cliente</param>
        /// <param name="apellido">apellido del cliente</param>
        public Cliente(int id,string dni, string nombre, string apellido)
        { 
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;

        }
        /// <summary>
        /// propiedad que asigan y retorna el id del cliente
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
        /// propiedad que asigan y retorna el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        /// <summary>
        /// propiedad que asigna y retorna el apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
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
        protected string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Id}    {this.Nombre}    {this.Apellido}    {this.Dni}");
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
        /// dos clientes son iguales si coinciden en nombre y apellido
        /// </summary>
        /// <param name="c1">primer cliente a evaluar</param>
        /// <param name="c2">segundo cliente a evaluar</param>
        /// <returns>devuelve true si son iguales, false si no lo son</returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            if(!(c1 is null || c2 is null))
            {
                return c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido;
            }
            return false;
        }
        /// <summary>
        /// dos clientes son distintos si su nombre o apellido son distintos
        /// </summary>
        /// <param name="c1">primer cliente a evaluar</param>
        /// <param name="c2">segundo cliente a evaluar</param>
        /// <returns>devuelve false si son iguales, true si no lo son</returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            if(!(c1 is null && c2 is null))
            {
                return !(c1 == c2);
            }
            return false;
        }

    }
}
