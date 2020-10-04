using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }

        ETipo tipo;

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será Cuatro puertas
        /// </summary>
        /// <param name="marca">marca del vehiculo</param>
        /// <param name="chasis">chasis del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor de un vehiculo sedan
        /// </summary>
        /// <param name="marca">marca del vehiculo</param>
        /// <param name="chasis">chasis del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        /// <param name="tipo">tipo del vehiculo (cuatro puertas o cinco puertas)</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca,chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Publica los datos del vehiculo Sedan
        /// </summary>
        /// <returns>devuelve un string con los datos compleatos del vehiculo sedan</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"TAMAÑO : {this.Tamanio}TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
