using Domain.Model.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICatteryRepository
    {
        // Metodi per i gatti
        bool SaveCats(List<Cat> cats);
        List<Cat> LoadCats();

        // Metodi per gli adottanti
        bool SaveAdopters(List<Adopter> adopters);
        List<Adopter> LoadAdopters();

        // Metodi per le adozioni
        bool SaveAdoptions(List<Adoption> adoptions);
        List<Adoption> LoadAdoptions();
    }
}