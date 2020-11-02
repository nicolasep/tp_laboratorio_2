using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace MiTest
{
    [TestClass]
    public class ValidaColeccionProfesorInstancia
    {
        [TestMethod]
        public void TestMethod1()
        {
            Profesor p1 = new Profesor(1,"sdsd","rferfe","35666666",Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Laboratorio, p1);

            bool resultado = false;

            if(j1.Alumnos != null)
            {
                resultado = true;
            }


            Assert.IsTrue(resultado);
        }
    }
}
