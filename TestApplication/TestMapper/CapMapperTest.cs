using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.ValueObjects;

namespace TestApplication.TestMapper
{
    [TestClass]
    public class CapMapperTest
    {
        [TestMethod]
        public void ToEntity_WithValidDto_CreatesCap()
        {
            var dto = new CapDTO { value = "00100" };
            Cap cap = CapMapper.ToEntity(dto);
            Assert.AreEqual(dto.value, cap.Value);
        }

        [TestMethod]
        public void ToDTO_WithValidCap_ReturnsDtoWithValue()
        {
            var cap = new Cap("00100");
            CapDTO dto = CapMapper.ToDTO(cap);
            Assert.AreEqual(cap.Value, dto.value);
        }

        [TestMethod]
        public void ToEntity_NullDto_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => CapMapper.ToEntity(null));
        }

        [TestMethod]
        public void ToEntity_InvalidValue_ThrowsArgumentException()
        {
            var dto = new CapDTO { value = "12" };
            Assert.ThrowsException<ArgumentException>(() => CapMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToDTO_NullCap_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => CapMapper.ToDTO(null));
        }
    }
}