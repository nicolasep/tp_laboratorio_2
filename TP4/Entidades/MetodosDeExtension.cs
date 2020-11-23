using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodosDeExtension
    { 
        /// <summary>
        /// evalua que la cadena pasada por parametro sea un numero valido como dni
        /// </summary>
        /// <param name="cadena">string a analizar</param>
        /// <returns>devuelve true si es dni valido, false si no lo es</returns>
        public static bool EsDniValido(this string cadena)
        {
            if(cadena.Length == 8)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] < '1' || cadena[i] > '9')
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
        /// <summary>
        /// evalua si el string es valido como nombre o apellido
        /// </summary>
        /// <param name="cadena">string a analizar</param>
        /// <returns>devuelve true si es valido, false si no lo es</returns>
        public static bool EsNombreOApellidoValido(this string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i] < 'a' || cadena[i] > 'z')&& (cadena[i] < 'A' || cadena[i] > 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
