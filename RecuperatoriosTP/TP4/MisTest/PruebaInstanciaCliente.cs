using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace MisTest
{
    [TestClass]
    public class PruebaInstanciaCliente
    {
        [TestMethod]
        public void AsignacionIdCliente()
        {
            Cliente cliente = new Cliente(0, "10222555", "Ramon", "Valdez");
            Clientes lista = new Clientes();
            lista.AgregarCliente(cliente);

            
        
            bool retorno = false;
            if(lista.ListaClientes[0].Id > 0)
            { 
                retorno = true;
            }
                     
            Assert.IsTrue(retorno);
        }
    }
}
