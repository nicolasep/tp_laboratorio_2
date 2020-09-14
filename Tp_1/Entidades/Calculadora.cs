using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// realiza operacion pasada como operador entre 2 numeros pasados por parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>devuelve el resultado de la operacion si salio bien, de lo contrario devuelve 0</returns>
        public static double Operar(Numero num1,Numero num2,string operador)
        {
            char calculo;
            double resultado = 0;
            char.TryParse(operador, out calculo);
            switch (ValidarOperador(calculo))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }
        /// <summary>
        /// valida si el tipo de operacion elejido esta dentro de los requeridos
        /// </summary>
        /// <param name="operador">tipo de operacion a realizar</param>
        /// <returns>si es una operacion aceptada la devuelve, de lo contrario devuelve un + </returns>
        private static string ValidarOperador(char operador)
        {

            if(operador != '-' && operador != '+' && operador !='/' && operador != '*')
            {
                operador = '+';
            }
            return operador.ToString();
        }
    }
}
