using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class PhoneNumberDTOTest
    {
        [TestMethod]
        public void Create_WithValue_SetsValue()
        {
            var dto = new PhoneNumberDTO { value = "333222111" };
            Assert.AreEqual("333222111", dto.value);
        }

        [TestMethod]
        public void Create_Default_HasNullValue()
        {
            var dto = new PhoneNumberDTO();
            Assert.IsNull(dto.value);
        }
    }
}