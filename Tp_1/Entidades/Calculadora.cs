using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
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
