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
            
            Clientes clientes = new Clientes();
            productos += p1;
            productos += p2;
            productos += p3;
            productos += p4;
            productos += p5;
            productos += p6;
            Console.WriteLine("-------------LISTA DE PRODUCTOS--------------------");
            Console.WriteLine(productos.Mostrar());
            Console.WriteLine("---------------------------------------------------");
            try
            {
                
                
                Cliente cliente = new Cliente("32556448", "chespirito", "barbosa");
                cliente = clientes.AgregarCliente(cliente);
                Alquilar clienteAlquiler = new Alquilar(cliente);
                Console.WriteLine("---------------------------------");
                clienteAlquiler.AgregarProducto(p1, 1000);//LANZA LA EXCEPCIO POR QUE NO HAY ESA CANTIDAD DISPONIBLE
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

            Console.WriteLine("---------------------------------");
            try
            {

               
                Cliente cliente2 = new Cliente("32556448", "DIEGO", "MARADONA");
                cliente2= clientes.AgregarCliente(cliente2);
                Alquilar clienteAlquiler2 = new Alquilar(cliente2);
                Console.WriteLine("---------------------------------");
                clienteAlquiler2.AgregarProducto(p1, 10);
                clienteAlquiler2.AgregarProducto(p2, 1);
                clienteAlquiler2.AgregarProducto(p3, 5);
                clienteAlquiler2.ConcretarOperacion();
                Console.WriteLine("------------factura------------");
                Console.WriteLine(clienteAlquiler2.Mostrar());
                Console.WriteLine("---------------------------------");

            }
            catch (ProductoDuplicadoExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            try
            {
                Cliente cliente3 = new Cliente("32557448", "SUSANA", "GIMENEZ");
                cliente3 = clientes.AgregarCliente(cliente3);
                Compra compra = new Compra(cliente3);
                compra.AgregarProducto(p3, 1000);//LANZA EXCEPCION POR  QUE NO HAY 1000 EN STOCK
                compra.AgregarProducto(p4, 1);
                compra.AgregarProducto(p5, 1);
                compra.ConcretarOperacion();
                Console.WriteLine("-----------factura------------");
                Console.WriteLine(compra.Mostrar());
                Console.WriteLine("---------------------------------");

                
            }
            catch (ProductoDuplicadoExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("---------------------------------");


            try
            {
                Cliente cliente3 = new Cliente("32557448", "Juan", "Perez");
                cliente3 = clientes.AgregarCliente(cliente3);
                Compra compra2 = new Compra(cliente3);
                compra2.AgregarProducto(p3, 10);
                compra2.AgregarProducto(p4, 1);
                compra2.AgregarProducto(p5, 1);
                compra2.ConcretarOperacion();
                Console.WriteLine("-----------factura------------");
                Console.WriteLine(compra2.Mostrar());
                Console.WriteLine("---------------------------------");

                
            }
            catch (ProductoDuplicadoExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("-------------LISTA DE PRODUCTOS--------------------");
            Console.WriteLine(productos.Mostrar());
            Console.WriteLine("---------------------------------");

            Console.WriteLine("---------MOVIMIENTOS----------------");
            List<string> movimientos = MovimientosDAO.RecuperarDatos();
            if(movimientos.Count > 0)
            {
                foreach (string mov in movimientos)
                {
                    Console.WriteLine(mov);
                }

            }



            Console.ReadKey();
        }
    }
}
