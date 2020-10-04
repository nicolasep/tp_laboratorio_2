using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        #region "constructores"
        /// <summary>
        /// Constructor de un objeto vehiculo
        /// </summary>
        /// <param name="chasis">chasis del vehiculo</param>
        /// <param name="marca">marca del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected virtual ETamanio Tamanio 
        {
            get;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>devuelve una cadena de caracteres con los datos del vehiculo</returns>
        public virtual string Mostrar()
       {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA : {this.marca}");
            sb.AppendLine($"COLOR : {this.color}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region "Opereadores"
        /// <summary>
        /// convierte un vehiculo con sus datos a string
        /// </summary>
        /// <param name="p">devuelve una cadena con los datos del vehiculo</param>
        public static explicit operator string(Vehiculo p)
        {
            return p.Mostrar();
        }
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehiculo 2</param>
        /// <returns>devuelve true si su numero de chases es igual, false si no lo son</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehiculo 1</param>
        /// <param name="v2">Vehiculo 2</param>
        /// <returns>devuelve true si su numero de chasis son distintos, false si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        #endregion
    }
}
