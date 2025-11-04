using System;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication.TestDTO
{
    [TestClass]
    public class AdoptionDTOTest
    {
        // Verifica che la creazione di Adoption a partire da DTO (tramite mapper per cat e adopter)
        // mantenga i campi principali correttamente.
        [TestMethod]
        public void CreateAdoption_DaDtoValidi_MantieneCampiPrincipali()
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

            // converto DTO in entità e costruisco Adoption
            Cat catEntity = CatMapper.ToEntity(catDto);
            Adopter adopterEntity = AdopterMapper.ToEntity(adopterDto);
            Adoption adoption = new Adoption(catEntity, adoptionDate, adopterEntity);

            // controlli sui campi principali
            Assert.IsNotNull(adoption.AdoptedCat);
            Assert.AreEqual("Romeo", adoption.AdoptedCat.Name);
            Assert.AreEqual("Siamese", adoption.AdoptedCat.Breed);
            Assert.AreEqual(adoptionDate, adoption.AdoptionDate);
            Assert.IsNotNull(adoption.AdopterData);
            Assert.AreEqual("John", adoption.AdopterData.FirstName);
            Assert.AreEqual("Doe", adoption.AdopterData.LastName);
            Assert.AreEqual(Adoption.AdoptionStatus.Completed, adoption.Status);
        }

        // Verifica che creare un'adozione con data precedente all'arrivo del gatto lanci ArgumentException
        [TestMethod]
        public void CreateAdoption_DataPrimaDiArrivo_LanciaArgumentException()
        {
            // gatto con arrival dopo la data di adozione
            CatDTO catDto = new CatDTO(
                Name: "Gina",
                Breed: "Europeo",
                IsMale: false,
                BirthDate: new DateOnly(2024, 1, 1),
                DepartureDate: null,
                ArrivalDate: new DateOnly(2025, 12, 1),
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

            Cat catEntity = CatMapper.ToEntity(catDto);
            Adopter adopterEntity = AdopterMapper.ToEntity(adopterDto);

            Assert.ThrowsException<ArgumentException>(() => new Adoption(catEntity, adoptionDate, adopterEntity));
        }

        // Verifica comportamento di CancelAdoption: prima imposta cancelled, poi la seconda chiamata lancia InvalidOperationException
        [TestMethod]
        public void CancelAdoption_DoppiaChiamata_PrimaOkSecondaLanciaInvalidOperationException()
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
            Adopter adopterEntity = AdopterMapper.ToEntity(adopterDto);
            Adoption adoption = new Adoption(catEntity, adoptionDate, adopterEntity);

            // Verifica stato iniziale
            Assert.AreEqual(Adoption.AdoptionStatus.Completed, adoption.Status);

            // prima cancellazione
            adoption.CancelAdoption();

            // verifica che sia stata cancellata
            Assert.AreEqual(Adoption.AdoptionStatus.Cancelled, adoption.Status);

            // seconda cancellazione deve lanciare InvalidOperationException
            var exception = Assert.ThrowsException<InvalidOperationException>(() => adoption.CancelAdoption());
            Assert.IsNotNull(exception.Message); // Opzionale: verifica che ci sia un messaggio
        }
    }
}