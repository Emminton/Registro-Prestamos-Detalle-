using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro_Detalle_Aplicada_2.BLL;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Detalle_Aplicada_2.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Persona personas = new Persona();
            personas.PersonaId = 0;
            personas.Nombre = "Luis Migueldff";
            personas.Telefono = "829786352";
            personas.Cedula = "0561233359";
            personas.Direccion = "Duarte Los Espinolas";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonaBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Persona personas = new Persona();
            personas.PersonaId = 2;
            personas.Nombre = "Luis Migueldff";
            personas.Telefono = "829786352";
            personas.Cedula = "0561233359";
            personas.Direccion = "Duarte Los Espinolas";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonaBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonaBLL.Eliminar(2);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Persona personas = new Persona();
            personas = PersonaBLL.Buscar(2);

            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            var lista = new List<Persona>();
            lista = PersonaBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}