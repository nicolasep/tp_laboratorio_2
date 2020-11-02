using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace ClasesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]

    public class Universidad
    {
        /// <summary>
        /// Enumerado de tipos de clases
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// constructor sin parametros que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Propiedad de alumnos que guarda y devuelve la lista de alumnos
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
        /// Propiedad de instructores, guarda o devuelve la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de jordas, guarda o retorna la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Indexador de lista de jornadas
        /// </summary>
        /// <param name="i">la posicion a retornar o cargar</param>
        /// <returns>devuelve la lista de jornadas modificada</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        /*Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus
          Profesores, Alumnos y Jornadas.
          Leer de clase retornará un Universidad con todos los datos previamente serializados.*/
        /// <summary>
        /// Guarda los datos de la univesidad en un archivo serializado
        /// </summary>
        /// <param name="uni">Universidad a guardad</param>
        /// <returns>Retorna true si pudo guardar, false si no pudo</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> universidad = new Xml<Universidad>();
            
            return universidad.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Carga los datos de Universidad desde un archivo serializado
        /// </summary>
        /// <returns>Devuelve una universidad con los datos cargados</returns>
        public static Universidad Leer()
        {
            Universidad universidad;
            Xml<Universidad> archivoLeido = new Xml<Universidad>();
            archivoLeido.Leer("Universidad.xml", out universidad);
            return universidad;
        }
        /// <summary>
        /// Imprime los datos de la universidad
        /// </summary>
        /// <param name="uni">universidad a imprimir</param>
        /// <returns>Devuelve una cadenade caracteres con todos los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada l in uni.jornada)
            {
                sb.AppendLine(l.ToString());
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// Verifica si un alumno se encuentra inscripto en la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a evaluar</param>
        /// <param name="a">alumno a buscar</param>
        /// <returns>Devuelve true si el alumno se encuentra inscripo, false si no se encuentra</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno l in g.Alumnos)
            {
                if(l == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si un alumno no se encuentra inscripto en la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a evaluar</param>
        /// <param name="a">alumno a buscar</param>
        /// <returns>Devuelve false si el alumno se encuentra inscripo, true si no se encuentra</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si un profesor da clases en la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a evaluar</param>
        /// <param name="i">profesor a buscar</param>
        /// <returns>Devuelve true si el profesor se encuentra inscripo, false si no se encuentra</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor l in g.Instructores)
            {
                if (l == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Verifica si un profesor no se encuentra inscripto en la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a evaluar</param>
        /// <param name="a">profesor a buscar</param>
        /// <returns>Devuelve false si el profesor se encuentra inscripo, true si no se encuentra</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Verifica si una clase se dicta en la la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a verificar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>Devuelve true si la clase se encuentra en la universidad, false si no se encuentra</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor l in g.Instructores)
            {
                if(l == clase)
                {
                    return l;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica si una clase no se dicta en la la universidad y devuelve el resultado
        /// </summary>
        /// <param name="g">universidad a verificar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>Devuelve false si la clase se encuentra en la universidad, true si no se encuentra</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor l in g.Instructores)
            {
                if (l != clase)
                {
                    return l;
                }
            }
            return null;
        }
        /// <summary>
        /// Agrega una jornada a la universidad, con el profesor que pueda darla y los alumnos
        /// </summary>
        /// <param name="g">Universidad donde se agrega</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Una universidad con la nueva jordad cargada con el profesor y sus alumnos</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada aux;
            Profesor auxProfesor;

            if((auxProfesor = g == clase)!=null)
            {
                aux = new Jornada(clase, auxProfesor);
                foreach(Alumno l in g.Alumnos)
                {
                    if(l==clase)
                    {
                        aux.Alumnos.Add(l);
                    }
                }
                g.Jornadas.Add(aux);
            }
            return g;
        }
        /// <summary>
        /// Carga un alumno nuevo en la universidad y si se encuentra retorna una excepcion
        /// </summary>
        /// <param name="u">universidad donde se va a cargar el alumno</param>
        /// <param name="a">alumno a cargar</param>
        /// <returns>si el alumno no se encontraba, lo carga y devuelve la universidad con el mismo cargado, caso contrario devuelve una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }
        /// <summary>
        /// Carga un profesor nuevo en la universidad
        /// </summary>
        /// <param name="u">universidad donde se va a cargar el profesor</param>
        /// <param name="a">profesor a cargar</param>
        /// <returns>si el profesor no se encontraba, lo carga y devuelve la universidad con el mismo cargado, caso contrario no lo carga</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        /// <summary>
        /// Sobrecarga que hace publico los datos de la universidad
        /// </summary>
        /// <returns>devuelve un string con los datos de la universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
    }
}
