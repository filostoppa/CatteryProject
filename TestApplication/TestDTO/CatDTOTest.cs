using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class CatDTOTest
    {
        // test per verificare che la conversione da DTO a Entity e viceversa
        // mantenga correttamente tutti i dati
        [TestMethod]
        public void BidirectionalConversion_WithValidData_MaintainsAllFields()
        {
            // preparo un DTO con tutti i dati
            CatDTO dto = new CatDTO(
                Name: "Romeo",
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: new DateOnly(2025, 10, 15),
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto colore arancione"
            );

            // converto DTO in Entity e poi ancora in DTO
            Cat entity = CatMapper.ToEntity(dto);
            CatDTO reconvertedDTO = entity.ToDTO();

            Assert.AreEqual(dto.Name, reconvertedDTO.Name);
            Assert.AreEqual(dto.Breed, reconvertedDTO.Breed);
            Assert.AreEqual(dto.IsMale, reconvertedDTO.IsMale);
            Assert.AreEqual(dto.BirthDate, reconvertedDTO.BirthDate);
            Assert.AreEqual(dto.ArrivalDate, reconvertedDTO.ArrivalDate);
            Assert.AreEqual(dto.DepartureDate, reconvertedDTO.DepartureDate);
            Assert.AreEqual(dto.Description, reconvertedDTO.Description);
        }

        // Test per verificare che un nome vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyName_ThrowsException()
        {
            // creo un DTO con nome vuoto
            CatDTO dto = new CatDTO(
                Name: "",
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto molto carino"
            );

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }

        // Test per verificare che una razza vuota lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyBreed_ThrowsException()
        {
            CatDTO dto = new CatDTO(
                Name: "Romeo",
                Breed: "",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto molto carino"
            );

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }

        // Test per verificare che un nome null lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithNullName_ThrowsException()
        {
            CatDTO dto = new CatDTO(
                Name: null,
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto molto carino"
            );

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }
    }
}