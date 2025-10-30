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
            // preparo un DTO con tutti i dati
            AdopterDTO dtoOriginale = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // converto DTO in Entity
            Adopter entita = dtoOriginale.ToEntity();

            // Verifico che la conversione DTO in Entity abbia preservato i valori esperati
            Assert.AreEqual(dtoOriginale.FirstName, entita.FirstName);
            Assert.AreEqual(dtoOriginale.LastName, entita.LastName);
            Assert.AreEqual(dtoOriginale.City, entita.City);

            // i valueobjects dell'entity devono contenere i valori del DTO originale
            Assert.AreEqual(dtoOriginale.Address, entita.Address.Value);
            Assert.AreEqual(dtoOriginale.Phone, entita.Phone.Value);
            Assert.AreEqual(dtoOriginale.FiscalCode, entita.FiscalCode.Value);
            Assert.AreEqual(dtoOriginale.CityCap, entita.CityCap.Value);

            // converto l'entity di nuovo in DTO
            AdopterDTO dtoRiconvertito = entita.ToDTO();

            // Verifico la conversione Entity -> DTO per i campi semplici
            Assert.AreEqual(entita.FirstName, dtoRiconvertito.FirstName);
            Assert.AreEqual(entita.LastName, dtoRiconvertito.LastName);
            Assert.AreEqual(entita.City, dtoRiconvertito.City);

            // Per i valueobjects la rappresentazione nel DTO dipende dall'implementazione di ToDTO.
            // Qui verifichiamo che il DTO riconvertito corrisponda alla rappresentazione attuale fornita dal mapper:
            Assert.AreEqual(entita.Address.ToString(), dtoRiconvertito.Address);
            Assert.AreEqual(entita.Phone.ToString(), dtoRiconvertito.Phone);
            Assert.AreEqual(entita.FiscalCode.ToString(), dtoRiconvertito.FiscalCode);
            Assert.AreEqual(entita.CityCap.ToString(), dtoRiconvertito.CityCap);
        }

        // Test per verificare che un nome vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyFirstName_ThrowsException()
        {
            // creo un DTO con nome vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "",
                LastName: "Rossi",
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un cognome vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyLastName_ThrowsException()
        {
            // creo un DTO con cognome vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "",
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un nome null lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithNullFirstName_ThrowsException()
        {
            // creo un DTO con nome null
            AdopterDTO dto = new AdopterDTO(
                FirstName: null,
                LastName: "Rossi",
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un cognome null lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithNullLastName_ThrowsException()
        {
            // creo un DTO con cognome null
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: null,
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un indirizzo vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyAddress_ThrowsException()
        {
            // creo un DTO con indirizzo vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "",
                Phone: "3331234567",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un telefono vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyPhone_ThrowsException()
        {
            // creo un DTO con telefono vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "mario.rossi@example.com",
                Phone: "",
                FiscalCode: "RSSMRA80A01H501U",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }

        // Test per verificare che un codice fiscale vuoto lanci un'eccezione
        [TestMethod]
        public void ConversionToEntity_WithEmptyFiscalCode_ThrowsException()
        {
            // creo un DTO con codice fiscale vuoto
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Rossi",
                Address: "mario.rossi@example.com",
                Phone: "3331234567",
                FiscalCode: "",
                City: "Bologna",
                CityCap: "40100"
            );

            // mi aspetto un errore
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dto.ToEntity());
        }
    }
}