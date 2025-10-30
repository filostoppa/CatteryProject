using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApplication.TestApplication
{
    [TestClass]
    public class AdopterMapperTest
    {
        // Verifica che il mapper costruisca correttamente l'entità con i value object
        [TestMethod]
        public void ToEntity_ValidDto_CreatesAdopterWithCorrectValueObjects()
        {
            AdopterDTO dto = new AdopterDTO(
                FirstName: "John",
                LastName: "Doe",
                Address: "john.doe@example.com",
                Phone: "1234567890",
                FiscalCode: "JHNDOE80A01H501U",
                City: "New York",
                CityCap: "10001"
            );

            Adopter entity = AdopterMapper.ToEntity(dto);

            // campi semplici
            Assert.AreEqual(dto.FirstName, entity.FirstName);
            Assert.AreEqual(dto.LastName, entity.LastName);
            Assert.AreEqual(dto.City, entity.City);

            // value objects contengono i valori originali
            Assert.AreEqual(dto.Address, entity.Address.Value);
            Assert.AreEqual(dto.Phone, entity.Phone.Value);
            Assert.AreEqual(dto.FiscalCode, entity.FiscalCode.Value);
            Assert.AreEqual(dto.CityCap, entity.CityCap.Value);
        }

        // verifica che il mapper converta l'entità in DTO correttamente
        [TestMethod]
        public void ToDTO_ValidEntity_ReturnsDtoWithExpectedStrings()
        {
            // creo l'entità di dominio direttamente
            Email email = new Email("anna@dominio.com");
            PhoneNumber phone = new PhoneNumber("333222111");
            FiscalCode fiscal = new FiscalCode("ANNDOM80A01H501U");
            Cap cap = new Cap("00100");

            Adopter entity = new Adopter(
                firstName: "Anna",
                lastName: "Rossi",
                address: email,
                phone: phone,
                fiscalCode: fiscal,
                city: "Roma",
                cityCap: cap
            );

            AdopterDTO dto = AdopterMapper.ToDTO(entity);

            // campi semplici preservati
            Assert.AreEqual(entity.FirstName, dto.FirstName);
            Assert.AreEqual(entity.LastName, dto.LastName);
            Assert.AreEqual(entity.City, dto.City);

            // i mapper producono stringhe che contengono i value object; verifichiamo che contengano il valore
            Assert.IsTrue(dto.Address.Contains(entity.Address.Value));
            Assert.IsTrue(dto.Phone.Contains(entity.Phone.Value));
            Assert.IsTrue(dto.FiscalCode.Contains(entity.FiscalCode.Value));
            Assert.IsTrue(dto.CityCap.Contains(entity.CityCap.Value));
        }

        // email non valida deve provocare eccezione dal value object Email
        [TestMethod]
        public void ToEntity_InvalidEmail_ThrowsArgumentExceptionOrNull()
        {
            // email senza '@'
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Test",
                LastName: "User",
                Address: "invalid-email",
                Phone: "1234567890",
                FiscalCode: "JHNDOE80A01H501U",
                City: "City",
                CityCap: "10001"
            );

            // email può lanciare ArgumentNullException o ArgumentException a seconda del caso
            try
            {
                AdopterMapper.ToEntity(dto);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentNullException)
            {
                // OK
            }
            catch (ArgumentException)
            {
                // OK
            }
        }

        // telefono non valido deve lanciare ArgumentException
        [TestMethod]
        public void ToEntity_InvalidPhone_ThrowsArgumentException()
        {
            // telefono non numerico
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Test",
                LastName: "User",
                Address: "john@doe.com",
                Phone: "abcde12345",
                FiscalCode: "JHNDOE80A01H501U",
                City: "City",
                CityCap: "10001"
            );

            Assert.ThrowsException<ArgumentException>(() => AdopterMapper.ToEntity(dto));
        }

        // fiscal code non valido deve lanciare ArgumentException
        [TestMethod]
        public void ToEntity_InvalidFiscalCode_ThrowsArgumentException()
        {
            // fiscal code corto o non conforme
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Test",
                LastName: "User",
                Address: "john@doe.com",
                Phone: "1234567890",
                FiscalCode: "SHORTCODE",
                City: "City",
                CityCap: "10001"
            );

            Assert.ThrowsException<ArgumentException>(() => AdopterMapper.ToEntity(dto));
        }

        // CAP non valido deve lanciare ArgumentException
        [TestMethod]
        public void ToEntity_InvalidCap_ThrowsArgumentException()
        {
            // CAP non a 5 cifre
            AdopterDTO dto = new AdopterDTO(
                FirstName: "Test",
                LastName: "User",
                Address: "john@doe.com",
                Phone: "1234567890",
                FiscalCode: "JHNDOE80A01H501U",
                City: "City",
                CityCap: "12" // non valido
            );

            Assert.ThrowsException<ArgumentException>(() => AdopterMapper.ToEntity(dto));
        }
    }
}