using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace MiTest
{
    [TestClass]
    public class PruebaExcepcionAlumnoRepetido
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad universidad = new Universidad();
            Alumno a1 = new Alumno(1, "mauricio", "Lopez", "32666444", Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            bool carga = false;
            universidad += a1;

            try
            {
                universidad += a1;
            }
            catch(AlumnoRepetidoException)
            {
                carga = true;
            }

            Assert.IsTrue(carga);

        }
    }
}
