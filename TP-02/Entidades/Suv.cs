using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region "Constructores"
        /// <summary>
        /// Constructor de Suv
        /// </summary>
        /// <param name="marca">marca del vehiculo suv</param>
        /// <param name="chasis">chasis del vehiculo suv</param>
        /// <param name="color">color del vehiculo suv</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Publica los datos del vehiculo junto con los datos especificos del tipo
        /// </summary>
        /// <returns>devuelve una cadena con los datos del vhiculo tipo Suv</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
