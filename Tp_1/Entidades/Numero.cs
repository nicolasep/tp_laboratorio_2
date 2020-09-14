using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">cadena a convertir</param>
        /// <returns>el numero convertido a binario o valor invalido si no es un numero</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";
            int contador = 1;
            int multiplo = 1;
            double resultado = 0;

            if (EsBinario(binario)==true)
            {
                foreach (char letra in binario)
                {
                    multiplo = multiplo * contador;

                    contador = 2;

                }
                foreach (char l in binario)
                {

                    if (l == '1')
                    {
                        resultado += multiplo * 1;
                    }
                    multiplo /= 2;

                }
                    retorno = resultado.ToString();
            }

            return retorno;
        }
        /// <summary>
        /// convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>si es un numero lo devuelve convertido a binario, de lo contratio devuelve Valor invalido</returns>
        public static string DecimalBinario(double numero)
        {
           
            string resultado = "";
            int numeroEntero;
            int aux;
            numeroEntero = (int)numero;

            if (numeroEntero > 0)
            {
                
                    while (numeroEntero > 1)
                    {
                        aux = numeroEntero % 2;

                        resultado = Convert.ToString(aux) + resultado;
                        numeroEntero = numeroEntero / 2;
                    }
                    resultado = Convert.ToString(numeroEntero) + resultado;
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }
        /// <summary>
        /// convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">cadena a convertir</param>
        /// <returns>el numero convertido a binario o valor invalido si no es un numero</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor Invalido";
            double resultado;

            if(double.TryParse(numero,out resultado))
            {
                retorno = DecimalBinario(resultado);
            }

            return retorno;
        }
        /// <summary>
        /// verifica si el string pasado por parametro es un numero binario
        /// </summary>
        /// <param name="binario">cadena a analizar</param>
        /// <returns>devuelve true si es binario y false si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            foreach(char n in binario)
            {
                if(n != '0' && n != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// crea el objeto e inicializa el atributo numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// crea el objeto Numero y le carga el numero pasado por parametro
        /// </summary>
        /// <param name="numero">numero a ingresar</param>
        public Numero(double numero)
        {
            SetNumero(numero.ToString());
        }
        /// <summary>
        /// crea el objeto Numero y le carga la cadena como numero pasado por parametro
        /// </summary>
        /// <param name="strNumero">numero a ingresar dentro de una cadena</param>
        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }
        /// <summary>
        /// realiza la resta del atributo numero de los objetos Numero pasados por parametro y devuelve el resultado
        /// </summary>
        /// <param name="n1">objeto Numero 1</param>
        /// <param name="n2">ojeto Numero 2</param>
        /// <returns>devuelve la resta de los numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// realiza la multiplicacion del atributo numero de los objetos Numero pasados por parametro y devuelve el resultado
        /// </summary>
        /// <param name="n1">objeto Numero 1</param>
        /// <param name="n2">objeto Numero 2</param>
        /// <returns>devuelve la multiplicacion de los numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// realiza la division del atributo numero de los objetos Numero pasados por parametro y devuelve el resultado
        /// </summary>
        /// <param name="n1">objeto Numero 1</param>
        /// <param name="n2">objeto Numero 2</param>
        /// <returns>si n2 es distinto de 0 devuelve la division, caso contrario devuelve el numero minimo posible</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
           
            return retorno;
        }
        /// <summary>
        /// realiza la suma del atributo numero de los objetos Numero pasados por parametro y devuelve el resultado
        /// </summary>
        /// <param name="n1">objeto Numero 1</param>
        /// <param name="n2">objeto Numero 2</param>
        /// <returns>devuelve la suma de los numeros</returns>
        public static double operator +(Numero n1, Numero n2)
        {

            return n1.numero + n2.numero;
        }
        /// <summary>
        /// valida que la cadena pasada por parametro sea un numero
        /// </summary>
        /// <param name="strNumero">cadena a analizar</param>
        /// <returns>si es un numero lo de duelve, caso contrario devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero,out numero) == true)
            {
                numero = 0;
            }
            return numero;
        }
        /// <summary>
        /// carga el atributo numero del objeto con la cadena pasada por parametro si esta es un numero
        /// </summary>
        /// <param name="strNumero">cadena a ingresar en el campo</param>
        /// <returns>si es un numero devuelve true, de lo contrario devuelve false</returns>
        public bool SetNumero(string strNumero)
        {
            double resultado;
            resultado = ValidarNumero(strNumero);
            bool retorno = false;

            if (resultado != 0)
            {
                this.numero = resultado;
                retorno = true;
            }
            return retorno;
        }
    }
}
