using Application.Dto;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICatRepository
    {
        CatDTO AddCat(CatDTO dto);
        List<CatDTO> GetAllCats();
        CatDTO? GetById(string id);
        List<CatDTO> GetAvailableCats();
        bool UpdateDepartureDate(string id, DateOnly? departureDate);
        bool DeleteCat(string id);
    }
}