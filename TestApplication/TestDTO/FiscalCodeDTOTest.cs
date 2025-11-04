using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class FiscalCodeDTOTest
    {
        [TestMethod]
        public void Create_ConValore_ImpostaValue()
        {
            FiscalCodeDTO dto = new FiscalCodeDTO { value = "ANNDOM80A01H501U" };
            Assert.AreEqual("ANNDOM80A01H501U", dto.value);
        }

        [TestMethod]
        public void Create_SenzaValore_HaValueNull()
        {
            var dto = new FiscalCodeDTO();
            Assert.IsNull(dto.value);
        }
    }
}