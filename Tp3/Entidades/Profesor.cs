using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor statico que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor sin parametros que inicializa la lista de clases y le carga clases al atributo
        /// </summary>
        private Profesor():base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _RandomClases();
        }
        /// <summary>
        /// Constructor de Profesor que agrega los datos pasados por parametros al nuevo profesor
        /// </summary>
        /// <param name="id">legajo de lprofesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _RandomClases();
        }
        /// <summary>
        /// Genera clases aleatorias y las carga en la lista de clases del dia
        /// </summary>
        private void _RandomClases()
        {
            int clase = Profesor.random.Next(0, 3);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase);
            Thread.Sleep(2000);
            int clase2 = Profesor.random.Next(0, 3);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase2);

        }
        /// <summary>
        /// Imprime los datos del profesor con las clases que dicta
        /// </summary>
        /// <returns>devuelve un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.MostrarDatos()}{this.ParticiparEnClase()}");
            
            return sb.ToString();
        }
        /// <summary>
        /// Imprime la lista de clases que dicta el profesor
        /// </summary>
        /// <returns>string con el nomber de las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

             sb.AppendLine($"CLASES DEL DIA:");

             foreach (Universidad.EClases l in this.clasesDelDia)
             {
                 sb.AppendLine($"{l}");
             }


            return sb.ToString();
        }
        /// <summary>
        /// Convierte en publicos los datos del profesor
        /// </summary>
        /// <returns>devuelve un string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Verifica si el profesor dicta una clase y devuelve el resultado
        /// </summary>
        /// <param name="i">profesor a evaluar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>Devuelve true si el profesor dicta esa clase, false si no lo hace</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases l in i.clasesDelDia)
            {
                if(l == clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si el profesor no dicta una clase y devuelve el resultado
        /// </summary>
        /// <param name="i">profesor a evaluar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>Devuelve false si el profesor dicta esa clase, true si no lo hace</returns>
        public static bool operator !=(Profesor i , Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
