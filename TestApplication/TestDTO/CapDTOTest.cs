using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class CapDTOTest
    {
        [TestMethod]
        public void Create_WithValue_SetsValue()
        {
            var dto = new CapDTO { value = "00100" };
            Assert.AreEqual("00100", dto.value);
        }

        [TestMethod]
        public void Create_Default_HasNullValue()
        {
            var dto = new CapDTO();
            Assert.IsNull(dto.value);
        }
    }
}