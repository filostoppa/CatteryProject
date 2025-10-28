using Application.Dto;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    /// <summary>
    /// Interfaccia semplice che definisce i casi d'uso per i gatti (Cat).
    /// Stile volutamente elementare e sincrono.
    /// </summary>
    public interface ICatrepository
    {
        CatDTO AddCat(CatDTO dto);
        List<CatDTO> GetAllCats();
        CatDTO? GetById(string id);
        List<CatDTO> GetAvailableCats();
        bool UpdateDepartureDate(string id, DateOnly? departureDate);
        bool RemoveById(string id);
        void Seed(IEnumerable<CatDTO> cats);
    }
}