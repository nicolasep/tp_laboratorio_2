using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Tp4NicolasEduardoPerez
{
    class Test
    {
        static void Main(string[] args)
        {

            
            Producto p1 = new Producto("AS01", "AGUAS", 20001, 50);
            Producto p2 = new Producto("AS02", "USHUAIA", 22300, 50);
            Producto p3 = new Producto("AS03", "BACOPE", 16700, 50);
            Producto p4 = new Producto("AS04", "TRIA", 18350, 50);
            Producto p5 = new Producto("AS05", "TERMOPLAST", 15600, 50);
            Producto p6 = new Producto("AS06", "AQUAWORD", 10350, 50);
            Productos productos = new Productos();
            try
            {

                productos += p1;
                productos += p2;
                productos += p3;
                productos += p4;
                productos += p5;
                productos += p6;
                Cliente cliente = new Cliente("32556448", "chespirito", "barbosa");
                Alquilar clienteAlquiler = new Alquilar(cliente);
                clienteAlquiler.AgregarProducto(p1, 1);
                clienteAlquiler.AgregarProducto(p2, 1);
                clienteAlquiler.AgregarProducto(p3, 50);
                clienteAlquiler.ConcretarOperacion();
                Console.WriteLine("------------factura------------");
                Console.WriteLine(clienteAlquiler.Mostrar());
                Console.WriteLine("---------------------------------");

            }
            catch(ProductoDuplicadoExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Productos productos = new Productos();//cuando se crea productos recupera la lista de productos de la BD


            try
            {
                Cliente cliente2 = new Cliente("32557448", "Juan", "Perez");
                Compra compra = new Compra(cliente2);
                compra.AgregarProducto(p3, 1);
                compra.AgregarProducto(p4, 1);
                compra.AgregarProducto(p5, 1);
                compra.ConcretarOperacion();
                Console.WriteLine("-----------factura------------");
                Console.WriteLine(compra.Mostrar());
                Console.WriteLine("---------------------------------");

                Console.WriteLine("-------------LISTA DE PRODUCTOS--------------------");
                Console.WriteLine(productos.Mostrar());
            }
            catch (ProductoDuplicadoExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }


            /*
            
            
            Console.WriteLine("---------MOVIMIENTOS----------------");
            List<string> movimientos = clienteAlquiler.Movimientos();
            foreach(string mov in movimientos)
            {
                Console.WriteLine(mov);
            }*/



            Console.ReadKey();
        }
    }
}
