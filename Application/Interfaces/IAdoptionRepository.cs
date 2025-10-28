using Application.Dto;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    /// <summary>
    /// Interfaccia semplice per i casi d'uso relativi alle adozioni.
    /// Stile e firme coerenti con le altre interfacce del progetto.
    /// </summary>
    public interface IAdoptionRepository
    {
        AdoptionDTO AddAdoption(AdoptionDTO dto);
        List<AdoptionDTO> GetAllAdoptions();
        AdoptionDTO? GetByCatId(string catId);
        List<AdoptionDTO> GetByAdopter(AdopterDTO adopter);
        List<AdoptionDTO> GetByStatus(bool completed);
        bool CancelAdoption(AdoptionDTO dto);
        void Seed(IEnumerable<AdoptionDTO> adoptions);
    }
}