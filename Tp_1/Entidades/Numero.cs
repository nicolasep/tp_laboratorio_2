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

        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";
            int contador = 1;
            int multiplo = 1;
            double resultado = 0;

            if (EsBinario(binario)==true)
            {
                //logica para convertir
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
        public static string DecimalBinario(double numero)
        {
           // string retorno = "Valor Invalido";

            
            string resultado = "";
            int numeroEntero;
            int aux;
            //int.TryParse(numero.ToString(), out numeroEntero);
            numeroEntero = (int)numero;
            if (numeroEntero > 0)
            {
                //logica para convertir

                    while (numeroEntero > 1)
                    {
                        aux = numeroEntero % 2;

                        resultado = Convert.ToString(aux) + resultado;
                    numeroEntero = numeroEntero / 2;
                    Console.WriteLine("E numero es: {0} y el resultado es: {1}", numero, resultado);
                    }
                    resultado = Convert.ToString(numeroEntero) + resultado;
               // retorno = "Nomero convertido";
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }
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
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            SetNumero(numero.ToString());
        }
        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        } 
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
           
            return retorno;
        }
        public static double operator +(Numero n1, Numero n2)
        {

            return n1.numero + n2.numero;
        }
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero,out numero) == true)
            {
                numero = 0;
            }
            return numero;
        }

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
