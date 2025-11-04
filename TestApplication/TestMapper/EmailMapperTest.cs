using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.ValueObjects;

namespace TestApplication.TestMapper
{
    [TestClass]
    public class EmailMapperTest
    {
        [TestMethod]
        public void ToEntity_WithValidDto_CreatesEmail()
        {
            var dto = new EmailDTO { value = "user@example.com" };
            Email email = EmailMapper.ToEntity(dto);
            Assert.AreEqual(dto.value, email.Value);
        }

        [TestMethod]
        public void ToDTO_WithValidEmail_ReturnsDtoWithValue()
        {
            var email = new Email("user@example.com");
            EmailDTO dto = EmailMapper.ToDTO(email);
            Assert.AreEqual(email.Value, dto.value);
        }

        [TestMethod]
        public void ToEntity_NullDto_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EmailMapper.ToEntity(null));
        }

        [TestMethod]
        public void ToEntity_InvalidValue_ThrowsArgumentExceptionOrNull()
        {
            // Email ctor nel progetto lancia ArgumentNullException per email senza '@'
            var dto = new EmailDTO { value = "invalid-email" };
            Assert.ThrowsException<ArgumentNullException>(() => EmailMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToDTO_NullEmail_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EmailMapper.ToDTO(null));
        }
    }
}