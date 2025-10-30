using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    [TestClass]
    public class AdoptionMapperTest
    {
        [TestMethod]
        public void Mapping_Preserves_MainFields()
        {
            CatDTO catDto = new CatDTO(
                Name: "Romeo",
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto colore arancione"
            );

            AdopterDTO adopterDto = new AdopterDTO(
                FirstName: "John",
                LastName: "Doe",
                Address: "john.doe@example.com",
                Phone: "1234567890",
                FiscalCode: "JHNDOE80A01H501U",
                City: "New York",
                CityCap: "10001"
            );

            AdoptionDTO dto = new AdoptionDTO(
                AdoptedCat: catDto,
                AdoptionDate: new DateOnly(2025, 10, 20),
                AdopterData: adopterDto,
                Status: true
            );

            // DTO -> domain entity -> DTO
            Adoption entity = AdoptionMapper.ToEntity(dto);
            AdoptionDTO dtoBack = entity.ToDTO();

            Assert.AreEqual(dto.AdoptionDate, dtoBack.AdoptionDate);
            Assert.AreEqual(dto.Status, dtoBack.Status);
            Assert.IsNotNull(dtoBack.AdoptedCat);
            Assert.AreEqual(dto.AdoptedCat.Name, dtoBack.AdoptedCat.Name);
            Assert.AreEqual(dto.AdoptedCat.Breed, dtoBack.AdoptedCat.Breed);
            Assert.IsNotNull(dtoBack.AdopterData);
            Assert.AreEqual(dto.AdopterData.FirstName, dtoBack.AdopterData.FirstName);
            Assert.AreEqual(dto.AdopterData.LastName, dtoBack.AdopterData.LastName);
        }

        [TestMethod]
        public void Mapping_NullFields_ThrowsArgumentNullException()
        {
            // DTO con campi null: il dominio richiede cat e adopter validi => mapper lancia
            AdoptionDTO dto = new AdoptionDTO(
                AdoptedCat: null,
                AdoptionDate: new DateOnly(2025, 1, 1),
                AdopterData: null,
                Status: false
            );

            Assert.ThrowsException<ArgumentNullException>(() => AdoptionMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToEntityAndToDTO_ReturnsSameValue()
        {
            CatDTO catDto = new CatDTO(
                Name: "Luna",
                Breed: "Europeo",
                IsMale: false,
                BirthDate: null,
                DepartureDate: null,
                ArrivalDate: new DateOnly(2024, 6, 1),
                Description: "Gatta simpatica"
            );

            AdopterDTO adopterDto = new AdopterDTO(
                FirstName: "Anna",
                LastName: "Rossi",
                Address: "anna.rossi@example.com",
                Phone: "333222111",
                FiscalCode: "ANNRSS80A01H501U",
                City: "Roma",
                CityCap: "00100"
            );

            AdoptionDTO original = new AdoptionDTO(catDto, new DateOnly(2024, 7, 1), adopterDto, true);

            Adoption entity = AdoptionMapper.ToEntity(original);
            AdoptionDTO finalDto = entity.ToDTO();

            Assert.AreEqual(original.AdoptionDate, finalDto.AdoptionDate);
            Assert.AreEqual(original.Status, finalDto.Status);
            Assert.IsNotNull(finalDto.AdoptedCat);
            Assert.AreEqual(original.AdoptedCat.Name, finalDto.AdoptedCat.Name);
            Assert.AreEqual(original.AdopterData.FirstName, finalDto.AdopterData.FirstName);
        }
    }
}
