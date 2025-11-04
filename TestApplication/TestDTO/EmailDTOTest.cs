using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class EmailDTOTest
    {
        [TestMethod]
        public void Create_WithValue_SetsValue()
        {
            var dto = new EmailDTO { value = "user@example.com" };
            Assert.AreEqual("user@example.com", dto.value);
        }

        [TestMethod]
        public void Create_Default_HasNullValue()
        {
            var dto = new EmailDTO();
            Assert.IsNull(dto.value);
        }
    }
}