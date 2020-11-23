using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace MisTest
{
    [TestClass]
    public class PruebaDeAgregarProductosAAlquiler
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cliente cliente = new Cliente(0, "10222555", "Ramon", "Valdez");
            Alquilar alquilar = new Alquilar(cliente);
            Producto producto = ProductosDAO.ListarProductosPorId(1);
            alquilar.AgregarProducto(producto, 5);
            bool retorno = false;
            if(alquilar.ListaDeProductos.Count > 0)
            {
                foreach(Producto p in alquilar.ListaDeProductos)
                {
                    if(p == producto)
                    {
                        retorno = true;
                    }
                }
                
            }
                     
            Assert.IsTrue(retorno);
        }
    }
}
