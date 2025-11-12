using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestDomain
{
    [TestClass]
    public class AdoptionTests
    {
        [TestMethod]
        public void Adoption_CreateAdoption_Success()
        {
            var cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 07, 2), new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), "gatto colore arancione");
            var email = new Email("jhon.doe@gmail.com");
            var notes = "Some notes";
            var phoneNumber = new PhoneNumber("1234567890");
            var fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            var cityCap = new Cap("10001");
            var adopter = new Adopter("John", "Doe", email, notes, phoneNumber, fiscalCode, "New York", cityCap);

            var adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter);

            Assert.AreEqual(cat, adoption.AdoptedCat);
            Assert.AreEqual(new DateOnly(2025, 10, 20), adoption.AdoptionDate);
            Assert.AreEqual(adopter, adoption.AdopterData);
            Assert.AreEqual(Adoption.AdoptionStatus.Completed, adoption.Status);
        }

        [TestMethod]
        public void Adoption_CancelAdoption_Success()
        {
            var cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 07, 2), new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), "gatto colore arancione");
            var email = new Email("jhon.doe@gmail.com");
            var notes = "Some notes";
            var phoneNumber = new PhoneNumber("1234567890");
            var fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            var cityCap = new Cap("10001");
            var adopter = new Adopter("John", "Doe", email, notes, phoneNumber, fiscalCode, "New York", cityCap);

            var adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter);
            adoption.CancelAdoption();

            Assert.AreEqual(Adoption.AdoptionStatus.Cancelled, adoption.Status);
        }

        [TestMethod]
        public void Adoption_CancelAdoption_AlreadyCancelled_ThrowsException()
        {
            var cat = new Cat("Romeo", "Siamese", true, new DateOnly(2025, 07, 2), new DateOnly(2025, 08, 19), new DateOnly(2025, 10, 20), "gatto colore arancione");
            var email = new Email("jhon.doe@gmail.com");
            var notes = "Some notes";
            var phoneNumber = new PhoneNumber("1234567890");
            var fiscalCode = new FiscalCode("JHNDOE80A01H501U");
            var cityCap = new Cap("10001");
            var adopter = new Adopter("John", "Doe", email, notes, phoneNumber, fiscalCode, "New York", cityCap);

            var adoption = new Adoption(cat, new DateOnly(2025, 10, 20), adopter);
            adoption.CancelAdoption();

            var exception = Assert.ThrowsException<InvalidOperationException>(() => adoption.CancelAdoption());
            Assert.AreEqual("The adoption is already cancelled.", exception.Message);
        }

        [TestMethod]
        public void Adoption_CreateAdoption_WithAdoptionDateBeforeArrivalDate_ThrowsException()
        {
            var cat = new Cat("Micio", "Persiano", true, new DateOnly(2025, 07, 1), new DateOnly(2025, 09, 15), null, "gatto grigio");
            var email = new Email("jane.doe@gmail.com");
            var notes = "Some notes";
            var phoneNumber = new PhoneNumber("0987654321");
            var fiscalCode = new FiscalCode("JANEDOE85B02H502V");
            var cityCap = new Cap("90001");
            var adopter = new Adopter("Jane", "Doe", email, notes, phoneNumber, fiscalCode, "Los Angeles", cityCap);

            var exception = Assert.ThrowsException<ArgumentException>(() =>
                new Adoption(cat, new DateOnly(2025, 09, 10), adopter));

            Assert.AreEqual("The adoption date cannot be earlier than the cat's arrival date.", exception.Message);
            Assert.AreEqual("adoptionDate", exception.ParamName);
        }
    }
}