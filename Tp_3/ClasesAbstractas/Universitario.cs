using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;


        /// <summary>
        /// Constructor de Universitario sin parametros
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor de Universitario con los datos pasados por parametros
        /// </summary>
        /// <param name="legajo">legajo del universitario</param>
        /// <param name="nombre">nombre del universitario</param>
        /// <param name="apellido">apellido del universitario</param>
        /// <param name="dni">dni del universitario</param>
        /// <param name="nacionalidad">nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.Legajo = legajo;
        }
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }
        /// <summary>
        /// Imprime los datos del universitario
        /// </summary>
        /// <returns>Devuelve un string con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"LEGAJO NUMERO: {this.Legajo}");
            return sb.ToString();
        }
        /// <summary>
        /// Metodo abstracto 
        /// </summary>
        /// <returns>Devuevle un string con los datos</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Verifica si el objeto pasado por parametro es un universitario
        /// </summary>
        /// <param name="obj">objero a evaluar</param>
        /// <returns>Devuelve true si es universitario, false si no lo es</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        /// <summary>
        /// Un universitario es igual a otro si aparte de ser universitario coincide su lejago y/o dni
        /// </summary>
        /// <param name="pg1">primer universitario</param>
        /// <param name="pg2">segundo universitario</param>
        /// <returns>Devuelve true si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.Legajo == pg2.Legajo || pg1.DNI == pg2.DNI);
        }
        /// <summary>
        /// Un universitario es distinto a otro si no son del mismo tipo o no coincide su dni o legajo
        /// </summary>
        /// <param name="pg1">primer universitario</param>
        /// <param name="pg2">segundo universitario</param>
        /// <returns>Devuelve true si nos distintos, false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
