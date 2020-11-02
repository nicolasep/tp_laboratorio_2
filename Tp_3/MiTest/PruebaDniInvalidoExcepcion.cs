using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace MiTest
{
    [TestClass]
    public class PruebaDniInvalidoExcepcion
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool resultado = false;
            Profesor p1;

            try
            {
                p1 = new Profesor(1, "eeee", "ddddd","5dsd", Persona.ENacionalidad.Argentino);
            }
            catch(DniInvalidoException)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);
        }
    }
}
