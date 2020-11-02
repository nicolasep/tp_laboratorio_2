using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado de nacionalidad de la persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        private int dni;
        private string apellido;
        private string nombre;
        private ENacionalidad nacionalidad;
        

        /// <summary>
        /// Constructor de instancia sin parametros
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor de instancia de Persona con los datos pasados por parametros
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancia de Persona con los datos pasados por parametros
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido,int dni ,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor de instancia de Persona con los datos pasados por parametros
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// Propiedad para obtener y cargar la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad para obtener el dni de la persona y cargar un dni valido
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad para cargar un dni tipo string, validarlo y convertirlo a int
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad para obtener el apellido de la persona y cargar un apellido valido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad para obtener el nombre de la persona y cargar un nombre valido
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        
        /// <summary>
        /// Valida que el dni sea valido segun su numero y nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni de la persona</param>
        /// <returns>devuelve el dni validad si esta bien y si esta mal devuelve una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 90000000 && dato > 0)
            {
                
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;

                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            
            throw new DniInvalidoException();

        }
        /// <summary>
        /// Valida si el dni pasado por strin son solo numero y si corresponde a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">strin con el dni</param>
        /// <returns>devuelve el dni validado si salio bien y si no devuelve una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if (!int.TryParse(dato, out resultado) || dato.Length != 8)
            {
                throw new DniInvalidoException();
            }
            else
            {
                return ValidarDni(nacionalidad,resultado);
            }
            
        }
        /// <summary>
        /// Verifica si la cadena pasada por parametro es un nombre o apellido valido
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>Devuelve la cadena valida si esta bien o null si esta mal</returns>
        private string ValidarNombreApellido(string dato)
        {
            if(dato.Length >= 3)
            {
                foreach (char l in dato)
                {
                    if ((l < 'A' || l > 'Z') && (l < 'a' || l > 'z') && l != ' ')
                    {
                        return null;
                    }
                }
                return dato;
            }
            
            return null;
        }
        /// <summary>
        /// Hace publicos los datos de la persona
        /// </summary>
        /// <returns>Devuelve un string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO:  {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return sb.ToString();
        }

    }
}
