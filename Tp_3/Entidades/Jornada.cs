using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor privado que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia que crea una jornada con los datos pasados por parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Propiedad de lista de alumnos. Guarda y restorna la lista
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de clases de la jornada que carga y retorna las mismas
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de instructor que carga o devuelve el profesor de esa jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Metodo declase que devuelve una cadena con los detos de la jornada desde un archivo de texto
        /// </summary>
        /// <returns>Devuelve un string con los datos leidos del archivo</returns>
        public static string Leer()
        {
            Texto leer = new Texto();
            string jorganda;
            if(leer.Leer("Jornada.txt",out jorganda))
            {
                return jorganda;
            }
            return null;
        }
        /// <summary>
        /// Guarda los datos de la jornada pasada por parametro en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardad</param>
        /// <returns>Devuelve true si pudo guardar, false si no puedo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool guardo = false;
            Texto texto = new Texto();
            if(texto.Guardar("Jornada.txt", jornada.ToString()))
            {
                guardo = true;
            }

            return guardo;
        }
        /// <summary>
        /// El alumno es igual a la jornada si esta en ella
        /// </summary>
        /// <param name="j">jonada a evalual</param>
        /// <param name="a">alumno a buscar</param>
        /// <returns>Devuelve true si el alumno se encuentr, false si no se encuentra</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno l in j.Alumnos)
            {
                if (l == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// El alumno es distinto a la jornada si esta en ella
        /// </summary>
        /// <param name="j">jonada a evalual</param>
        /// <param name="a">alumno a buscar</param>
        /// <returns>Devuelve false si el alumno se encuentr, true si no se encuentra</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {

            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada si el mismo no se encuentra
        /// </summary>
        /// <param name="j">jornada donde se va a agregar</param>
        /// <param name="a">alumno a agregar</param>
        /// <returns>Devuelve la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// Hace publicos los datos de la Jornada
        /// </summary>
        /// <returns>Devuelve un string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            sb.AppendLine($"ALUMNOS: ");
            foreach (Alumno l in this.Alumnos)
            {
                sb.Append($"{l.ToString()}");
            }
            sb.AppendLine("<---------------------------------------->");
            return sb.ToString();
        }

        

    }
}
