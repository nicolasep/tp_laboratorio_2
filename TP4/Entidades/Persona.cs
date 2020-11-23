using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;

        /// <summary>
        /// constructor de persona
        /// </summary>
        /// <param name="nombre">nombre de la parsona</param>
        /// <param name="apellido">apellido de la persona</param>
        public Persona(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;

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
        /// publica los datos de la persona
        /// </summary>
        /// <returns>retorna un strin con los datos de la persona</returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append($"Nombre: {this.Nombre} Apellido: {this.Apellido}");
            sb.Append($"{this.Nombre} {this.Apellido}");
            return sb.ToString();
        }
    }
}
