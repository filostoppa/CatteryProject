using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication
{
    [TestClass]
    public class AdoptionMapperTest
    {
        [TestMethod]
        public void Mapping_Preserves_MainFields()
        {
            // preparo DTO per cat e adopter
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

            AdoptionDTO mapped = AdoptionMapper.ToEntity(dto);
            AdoptionDTO dtoBack = mapped.ToDTO();

            // verifica campi principali
            Assert.AreEqual(dto.AdoptionDate, mapped.AdoptionDate);
            Assert.AreEqual(dto.Status, mapped.Status);

            Assert.IsNotNull(mapped.AdoptedCat);
            Assert.AreEqual(dto.AdoptedCat.Name, mapped.AdoptedCat.Name);
            Assert.AreEqual(dto.AdoptedCat.Breed, mapped.AdoptedCat.Breed);

            Assert.IsNotNull(mapped.AdopterData);
            Assert.AreEqual(dto.AdopterData.FirstName, mapped.AdopterData.FirstName);
            Assert.AreEqual(dto.AdopterData.LastName, mapped.AdopterData.LastName);

            Assert.AreEqual(dto.AdoptionDate, dtoBack.AdoptionDate);
            Assert.AreEqual(dto.Status, dtoBack.Status);
        }

        [TestMethod]
        public void Mapping_SupportsNullFields()
        {
            // DTO con campi null per cat e adopter
            AdoptionDTO dto = new AdoptionDTO(
                AdoptedCat: null,
                AdoptionDate: new DateOnly(2025, 1, 1),
                AdopterData: null,
                Status: false
            );

            AdoptionDTO mapped = AdoptionMapper.ToEntity(dto);
            AdoptionDTO dtoBack = mapped.ToDTO();

            // campi null 
            Assert.IsNull(mapped.AdoptedCat);
            Assert.IsNull(mapped.AdopterData);
            Assert.AreEqual(dto.Status, mapped.Status);
            Assert.AreEqual(dto.AdoptionDate, mapped.AdoptionDate);

            Assert.IsNull(dtoBack.AdoptedCat);
            Assert.IsNull(dtoBack.AdopterData);
            Assert.AreEqual(dtoBack.Status, dto.Status);
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

            AdoptionDTO mid = AdoptionMapper.ToEntity(original);
            AdoptionDTO finalDto = mid.ToDTO();

            // tutti i campi principali coincidono
            Assert.AreEqual(original.AdoptionDate, finalDto.AdoptionDate);
            Assert.AreEqual(original.Status, finalDto.Status);

            Assert.IsNotNull(finalDto.AdoptedCat);
            Assert.AreEqual(original.AdoptedCat.Name, finalDto.AdoptedCat.Name);
            Assert.AreEqual(original.AdopterData.FirstName, finalDto.AdopterData.FirstName);
        }
    }
}
