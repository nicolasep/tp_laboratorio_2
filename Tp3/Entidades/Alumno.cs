using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// Enumerado de estados de cuenta disponibles
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor de instancia sin parametros
        /// </summary>
        public Alumno():base()
        {

        }
        /// <summary>
        /// Constructor de instancia con los datos del alumno pasados por parametros
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">string con el dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumni</param>
        /// <param name="claseQueToma">clase que noma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            
        }

        /// <summary>
        /// Constructor de instancia con los datos del alumno pasados por parametros
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumni</param>
        /// <param name="estadoCuenta">estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Imprime los datos del alumno
        /// </summary>
        /// <returns>Devuelve un string con los datos completos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append($"ESTADO DE CUENTA: ");
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("Cuota al dia");
            }
            else
            {
                sb.AppendLine($"{this.estadoCuenta}");
            }
            
            sb.AppendLine($"{this.ParticiparEnClase()}");

            return sb.ToString();
        }
        /// <summary>
        /// Emprime la clase en la que participa
        /// </summary>
        /// <returns>Devuelve un string con al clase en la que participa el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASE DE {this.claseQueToma}");
            
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos del alumno
        /// </summary>
        /// <returns>Devuelve una cadena con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un alumno es igual a la clase si toma esa clase
        /// </summary>
        /// <param name="a">alumno a conprobar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>devuelve true si el alumno toma esa clase, false si no la toma</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un alumno es distinto a la clase si no toma esa clase
        /// </summary>
        /// <param name="a">alumno a conprobar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>devuelve false si el alumno toma esa clase, true si no la toma</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
    }
}
