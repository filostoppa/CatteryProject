using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class FiscalCodeDTOTest
    {
        [TestMethod]
        public void Create_WithValue_SetsValue()
        {
            var dto = new FiscalCodeDTO { value = "ANNDOM80A01H501U" };
            Assert.AreEqual("ANNDOM80A01H501U", dto.value);
        }

        [TestMethod]
        public void Create_Default_HasNullValue()
        {
            var dto = new FiscalCodeDTO();
            Assert.IsNull(dto.value);
        }
    }
}