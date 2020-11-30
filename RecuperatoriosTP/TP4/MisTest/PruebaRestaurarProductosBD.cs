using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace MisTest
{
    [TestClass]
    public class PruebaRestaurarProductosBD
    {
        [TestMethod]
        public void InstanciaListaProd()
        {
            Productos prod = new Productos();
            bool resultado = false;

            if(prod.ListaProductos != null)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);

        }
    }
}
