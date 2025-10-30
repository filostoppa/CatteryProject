using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestApplication.TestApplication
{
    [TestClass]
    public class CatMapperTest
    {
        // Verifica il mapping corretto da DTO a Entity e ritorno in DTO
        [TestMethod]
        public void Mapping_Valid_DTO_ToEntity_And_Back()
        {
            // Arrange
            CatDTO dto = new CatDTO(
                Name: "Romeo",
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: new DateOnly(2025, 10, 15),
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "Gatto colore arancione"
            );

            // Act
            Cat entity = CatMapper.ToEntity(dto);
            CatDTO dtoBack = entity.ToDTO();

            // Assert - campi principali preservati
            Assert.AreEqual(dto.Name, entity.Name);
            Assert.AreEqual(dto.Breed, entity.Breed);
            Assert.AreEqual(dto.IsMale, entity.IsMale);
            Assert.AreEqual(dto.ArrivalDate, entity.ArrivalDate);
            Assert.AreEqual(dto.DepartureDate, entity.DepartureDate);
            Assert.AreEqual(dto.BirthDate, entity.BirthDate);
            Assert.AreEqual(dto.Description, entity.Description);

            // Assert mapping inverso
            Assert.AreEqual(dto.Name, dtoBack.Name);
            Assert.AreEqual(dto.Breed, dtoBack.Breed);
            Assert.AreEqual(dto.IsMale, dtoBack.IsMale);
            Assert.AreEqual(dto.ArrivalDate, dtoBack.ArrivalDate);
            Assert.AreEqual(dto.DepartureDate, dtoBack.DepartureDate);
            Assert.AreEqual(dto.BirthDate, dtoBack.BirthDate);
            Assert.AreEqual(dto.Description, dtoBack.Description);
        }

        // Nome vuoto deve generare eccezione dal dominio
        [TestMethod]
        public void ToEntity_EmptyName_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            CatDTO dto = new CatDTO(
                Name: "",
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "desc"
            );

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }

        // Razza vuota deve generare eccezione dal dominio
        [TestMethod]
        public void ToEntity_EmptyBreed_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            CatDTO dto = new CatDTO(
                Name: "Romeo",
                Breed: "",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "desc"
            );

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }

        // Nome null deve generare eccezione dal dominio
        [TestMethod]
        public void ToEntity_NullName_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            CatDTO dto = new CatDTO(
                Name: null,
                Breed: "Siamese",
                IsMale: true,
                BirthDate: new DateOnly(2025, 8, 10),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 8, 19),
                Description: "desc"
            );

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => CatMapper.ToEntity(dto));
        }
    }
}