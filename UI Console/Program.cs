using Application.Dto;
using Application.Mappers;
using Application.UseCases;
using Infrastracture.Persistance.Repositories;

namespace UI_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonCatteryRepository jsonCattery = new JsonCatteryRepository();
            CatteryService catteryService = new CatteryService();
            DateOnly arrivedDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly? birthDate = DateOnly.FromDateTime(new DateTime(2020, 5, 1));
            DateOnly? adoptedDate = null;
            CatDTO cat1 = new CatDTO("Rocco", "Arancione", true, birthDate, adoptedDate, arrivedDate, "Ha tendenze violente");
            CatDTO cat2 = new CatDTO("Brittany", "siberiana", false, birthDate, adoptedDate, arrivedDate, "");
            AdopterDTO adopter = new AdopterDTO("Maurizio", "Merluzzo", "maurizio.merluzzo@gmail.com", "1234567890", "MRLMRZ80C15B234K", "Capocolle", "47032");
            catteryService.AddCat(cat1);
            catteryService.AddCat(cat2);
        }
    }
}