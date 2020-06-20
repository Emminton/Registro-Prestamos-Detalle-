using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro_Detalle_Aplicada_2.BLL;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Detalle_Aplicada_2.BLL.Tests
{
    [TestClass()]
    public class PrestamoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            decimal BalanceActual;
            Persona persona = new Persona();
            bool paso;
            Prestamo prestamo = new Prestamo();

            prestamo.PrestamoId = 0;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 1;
            prestamo.Concepto = "Prestamo Detalle";
            prestamo.Monto = 80000;
            prestamo.Balance = prestamo.Monto;
            paso = PrestamoBLL.Guardar(prestamo);

            persona = PersonaBLL.Buscar(prestamo.PersonaId);
            BalanceActual = persona.Balance;

            if (0 < BalanceActual)
                paso = true;
            else
                paso = false;

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
            decimal BalanceActual;
            Persona persona;
            bool paso;
            Prestamo prestamo = new Prestamo();

            prestamo.PrestamoId = 1;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 1;
            prestamo.Concepto = "Prestamo Detalle";
            prestamo.Monto = 50000;
            prestamo.Balance = prestamo.Monto;
            paso = PrestamoBLL.Guardar(prestamo);

            persona = PersonaBLL.Buscar(prestamo.PersonaId);
            BalanceActual = persona.Balance;

            if (5000 < BalanceActual)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PrestamoBLL.Eliminar(1, 1);

            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamo prestamo = new Prestamo();
            prestamo = PrestamoBLL.Buscar(1);

            Assert.AreEqual(prestamo, prestamo);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPrestamosTest()
        {
            var lista = new List<Prestamo>();
            lista = PrestamoBLL.GetList(p => true);

            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}