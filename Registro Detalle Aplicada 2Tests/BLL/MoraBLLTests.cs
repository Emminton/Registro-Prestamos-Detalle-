using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro_Detalle_Aplicada_2.BLL;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Detalle_Aplicada_2.BLL.Tests
{
    [TestClass()]
    public class MoraBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Mora mora = new Mora();
            mora.MoraId = 0;
            mora.Fecha = DateTime.Now;
            mora.Total = 10;
            mora.MoraDetalle.Add(new MorasDetalle
            {
                MoraDetalleId = 0,
                MoraId = mora.MoraId,
                PrestamoId = 1,
                Valor = 10
            });

            Assert.IsTrue(MoraBLL.Guardar(mora));
        }

        //[TestMethod()]
        //public void InsertarTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ModificarTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = MoraBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Mora mora = new Mora();
            mora = MoraBLL.Buscar(1);
            Assert.IsNotNull(mora);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = MoraBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        //[TestMethod()]
        //public void GetMorasTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Mora>();
            lista = MoraBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}