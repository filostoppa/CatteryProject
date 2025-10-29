using Application.Dto;
using Application.Mappers;
using Domain.Model;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class AdopterDTOTest
    {
        // Test per verificare che la conversione da DTO a Entity e viceversa
        // mantenga correttamente tutti i dati
        [TestMethod]
        public void BidirectionalConversion_WithValidData_MaintainsAllFields()
        {
            // Arrange - preparo un DTO con tutti i dati
            AdopterDTO dtoOriginale = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act - converto DTO -> Entity -> DTO
            Adopter entita = dtoOriginale.ToEntity();
            AdopterDTO dtoRiconvertito = entita.ToDTO();

            // Assert - verifico che i dati siano rimasti uguali
            Assert.AreEqual(dtoOriginale.FirstName, dtoRiconvertito.FirstName);
            Assert.AreEqual(dtoOriginale.LastName, dtoRiconvertito.LastName);
            Assert.AreEqual(dtoOriginale.Address, dtoRiconvertito.Address);
            Assert.AreEqual(dtoOriginale.Phone, dtoRiconvertito.Phone);
            Assert.AreEqual(dtoOriginale.FiscalCode, dtoRiconvertito.FiscalCode);
            Assert.AreEqual(dtoOriginale.City, dtoRiconvertito.City);
            Assert.AreEqual(dtoOriginale.CityCap, dtoRiconvertito.CityCap);
        }

        // Test per verificare che un nome vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyFirstName_ThrowsException()
        {
            // Arrange - creo un DTO con nome vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "",
                LastName: "Rossi",
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un cognome vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyLastName_ThrowsException()
        {
            // Arrange - creo un DTO con cognome vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "",
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un nome null lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithNullFirstName_ThrowsException()
        {
            // Arrange - creo un DTO con nome null
            AdopterDTO dto = new AdopterDTO(
                FirstName: null,
                LastName: "Rossi",
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un cognome null lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithNullLastName_ThrowsException()
        {
            // Arrange - creo un DTO con cognome null
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: null,
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un indirizzo vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyAddress_ThrowsException()
        {
            // Arrange - creo un DTO con indirizzo vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un telefono vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyPhone_ThrowsException()
        {
            // Arrange - creo un DTO con telefono vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "Via Roma 123",
                Phone: "",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un codice fiscale vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyFiscalCode_ThrowsException()
        {
            // Arrange - creo un DTO con codice fiscale vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "Via Roma 123",
                Phone: "3331234567",
                FiscalCode: "",
                City: "Bologna",
                CityCap: "40100"
            );

            // Act & Assert - mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }
    }
}