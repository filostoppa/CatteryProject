using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApplication
{
    [TestClass]
    public class AdopterMapperTest
    {
        [TestMethod]
        public void ToEntity_WithValidDto_CreatesAdopterWithCorrectValueObjects()
        {
            AdopterDTO dto = new AdopterDTO(
                FirstName: "John",
                LastName: "Doe",
                Address: "john@doe.com",
                Phone: "1234567890",
                FiscalCode: "JHNDOE80A01H501U",
                City: "New York",
                CityCap: "10001"
            );

            Adopter entity = AdopterMapper.ToEntity(dto);

            // controllo i campi semplici
            Assert.AreEqual(dto.FirstName, entity.FirstName);
            Assert.AreEqual(dto.LastName, entity.LastName);
            Assert.AreEqual(dto.City, entity.City);

            // value objects contengono i valori originali
            Assert.AreEqual(dto.Address, entity.Address.Value);
            Assert.AreEqual(dto.Phone, entity.Phone.Value);
            Assert.AreEqual(dto.FiscalCode, entity.FiscalCode.Value);
            Assert.AreEqual(dto.CityCap, entity.CityCap.Value);
        }

        [TestMethod]
        public void ToDTO_WithValidEntity_ReturnsDtoWithMainFields()
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

            // campi semplici 
            Assert.AreEqual(entity.FirstName, dto.FirstName);
            Assert.AreEqual(entity.LastName, dto.LastName);
            Assert.AreEqual(entity.City, dto.City);

            // I mapper usano ToString() sui value objects: verifichiamo che la stringa DTO contenga il valore
            Assert.IsTrue(dto.Address.Contains(entity.Address.Value));
            Assert.IsTrue(dto.Phone.Contains(entity.Phone.Value));
            Assert.IsTrue(dto.FiscalCode.Contains(entity.FiscalCode.Value));
            Assert.IsTrue(dto.CityCap.Contains(entity.CityCap.Value));
        }

        [TestMethod]
        public void ToEntity_WithInvalidEmail_ThrowsException()
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

            Assert.ThrowsException<ArgumentNullException>(() => AdopterMapper.ToEntity(dto));
        }

        [TestMethod]
        public void ToEntity_WithInvalidPhone_ThrowsException()
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

        [TestMethod]
        public void ToEntity_WithInvalidFiscalCode_ThrowsException()
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

        [TestMethod]
        public void ToEntity_WithInvalidCap_ThrowsException()
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