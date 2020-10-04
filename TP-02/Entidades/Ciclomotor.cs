using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {

        #region "Constructores"
        /// <summary>
        /// Constructor de un ciclomotor
        /// </summary>
        /// <param name="marca">marca del ciclomotor</param>
        /// <param name="chasis">chasis del ciclomotor</param>
        /// <param name="color">color del ciclomotor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {

        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Publica los datos del ciclomotor
        /// </summary>
        /// <returns>devuelve un string con todos los datos del ciclomotor</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
