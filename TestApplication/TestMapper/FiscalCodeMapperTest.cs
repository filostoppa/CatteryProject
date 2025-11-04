using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Domain.Model.ValueObjects;

namespace TestApplication.TestMapper
{
    [TestClass]
    public class FiscalCodeMapperTest
    {
        [TestMethod]
        public void ToEntity_WithValidDto_CreatesFiscalCode()
        {
            var dto = new FiscalCodeDTO { value = "ANNDOM80A01H501U" };
            FiscalCode fiscal = FiscalCodeMapper.ToEntity(dto);
            Assert.AreEqual(dto.value, fiscal.Value);
        }

        [TestMethod]
        public void ToDTO_WithValidFiscal_ReturnsDtoWithValue()
        {
            var fiscal = new FiscalCode("ANNDOM80A01H501U");
            FiscalCodeDTO dto = FiscalCodeMapper.ToDTO(fiscal);
            Assert.AreEqual(fiscal.Value, dto.value);
        }

        [TestMethod]
        public void ToEntity_NullDto_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => FiscalCodeMapper.ToEntity(null));
        }

        [TestMethod]
        public void ToEntity_InvalidValue_ThrowsArgumentException()
        {
            var dto = new FiscalCodeDTO { value = "SHORT" };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => FiscalCodeMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToDTO_NullFiscal_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => FiscalCodeMapper.ToDTO(null));
        }
    }
}