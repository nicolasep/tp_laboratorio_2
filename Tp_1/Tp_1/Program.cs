using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCalculadora;
using Entidades;

namespace Tp_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero n1 = new Numero(3);
            Numero n2 = new Numero(5);
            Console.WriteLine("el num es: {0}", Calculadora.Operar(n1, n2, ""));
            //Console.WriteLine("el numero es {0}", Numero.DecimalBinario(6));
            Console.ReadKey();
        }
    }
}
