using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace MiTest
{
    [TestClass]
    public class ValidaInstanciaColeccionAlumnos
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad universidad = new Universidad();
            bool resultado = false;

            if(universidad.Alumnos != null && universidad.Instructores != null && universidad.Jornadas != null)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);
        }
    }
}
