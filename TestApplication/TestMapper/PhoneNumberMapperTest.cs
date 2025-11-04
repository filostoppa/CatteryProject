using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.ValueObjects;

namespace TestApplication.TestMapper
{
    [TestClass]
    public class PhoneNumberMapperTest
    {
        [TestMethod]
        public void ToEntity_WithValidDto_CreatesPhoneNumber()
        {
            var dto = new PhoneNumberDTO { value = "333222111" };
            PhoneNumber phone = PhoneNumberMapper.ToEntity(dto);
            Assert.AreEqual(dto.value, phone.Value);
        }

        [TestMethod]
        public void ToDTO_WithValidPhone_ReturnsDtoWithValue()
        {
            var phone = new PhoneNumber("333222111");
            PhoneNumberDTO dto = PhoneNumberMapper.ToDTO(phone);
            Assert.AreEqual(phone.Value, dto.value);
        }

        [TestMethod]
        public void ToEntity_NullDto_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PhoneNumberMapper.ToEntity(null));
        }

        [TestMethod]
        public void ToEntity_InvalidValue_ThrowsArgumentException()
        {
            var dto = new PhoneNumberDTO { value = "abc" };
            Assert.ThrowsException<ArgumentException>(() => PhoneNumberMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToDTO_NullPhone_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => PhoneNumberMapper.ToDTO(null));
        }
    }
}
