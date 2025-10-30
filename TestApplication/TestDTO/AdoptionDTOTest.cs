using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class AdoptionDTOTest
    {
        // Verifica che, usando i mapper pubblici, sia possibile costruire
        // un'entità Adoption valida a partire dagli application DTO
        [TestMethod]
        public void ToEntity_WithValidData_MaintainsMainFields()
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

            DateOnly adoptionDate = new DateOnly(2025, 10, 20);

            // uso i mapper pubblici per ottenere entità e creo Adoption
            Cat catEntity = CatMapper.ToEntity(catDto);
            Adopter adopterEntity = adopterDto.ToEntity();
            Adoption adoption = new Adoption(catEntity, adoptionDate, adopterEntity);

            // controllo campi principali
            Assert.AreEqual(catEntity, adoption.AdoptedCat);
            Assert.AreEqual(adoptionDate, adoption.AdoptionDate);
            Assert.AreEqual(adopterEntity, adoption.AdopterData);
            Assert.AreEqual(Adoption.AdoptionStatus.Completed, adoption.Status);
        }

        // Verifica che una data di adozione antecedente all'arrivo del gatto lanci eccezione
        [TestMethod]
        public void CreateAdoption_DateBeforeArrival_ThrowsArgumentException()
        {
            // gatto con arrival dopo la data di adozione
            CatDTO catDto = new CatDTO(
                Name: "Gina",
                Breed: "Europeo",
                IsMale: false,
                BirthDate: new DateOnly(2024, 1, 1),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 12, 1), // arriva il 1 dic 2025
                Description: "Gatta dolce"
            );

            AdopterDTO adopterDto = new AdopterDTO(
                FirstName: "Alice",
                LastName: "Rossi",
                Address: "alice.rossi@example.com",
                Phone: "0987654321",
                FiscalCode: "ALIRSS80A01H501U",
                City: "Roma",
                CityCap: "00100"
            );

            DateOnly adoptionDate = new DateOnly(2025, 11, 30); // prima dell'arrivo

            // la costruzione dell'entità Adoption deve fallire
            Cat catEntity = CatMapper.ToEntity(catDto);
            Adopter adopterEntity = adopterDto.ToEntity();

            Assert.ThrowsException<ArgumentException>(() => new Adoption(catEntity, adoptionDate, adopterEntity));
        }

        // verifica il comportamento di CancelAdoption: prima imposta cancelled, poi rilancia se già cancellata
        [TestMethod]
        public void CancelAdoption_DoubleCall_FirstSucceeds_SecondThrows()
        {
            // dati validi
            CatDTO catDto = new CatDTO(
                Name: "Micio",
                Breed: "Persiano",
                IsMale: true,
                BirthDate: new DateOnly(2023, 5, 1),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2024, 6, 1),
                Description: "Molto tranquillo"
            );

            AdopterDTO adopterDto = new AdopterDTO(
                FirstName: "Mario",
                LastName: "Bianchi",
                Address: "mario.bianchi@example.com",
                Phone: "333222111",
                FiscalCode: "MRBNC80A01H501U1",
                City: "Milano",
                CityCap: "20100"
            );

            DateOnly adoptionDate = new DateOnly(2024, 7, 1);

            Cat catEntity = CatMapper.ToEntity(catDto);
            Adopter adopterEntity = adopterDto.ToEntity();
            Adoption adoption = new Adoption(catEntity, adoptionDate, adopterEntity);

            // prima cancellazione
            adoption.CancelAdoption();
            Assert.AreEqual(Adoption.AdoptionStatus.Cancelled, adoption.Status);

            // seconda cancellazione deve lanciare InvalidOperationException
            Assert.ThrowsException<InvalidOperationException>(() => adoption.CancelAdoption());
        }
    }
}