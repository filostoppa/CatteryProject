using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static AdoptionDTO ToEntity (AdoptionDTO dto)
        {
            return new AdoptionDTO
                (
                AdoptedCat: dto.AdoptedCat,
                AdoptionDate: dto.AdoptionDate,
                AdopterData: dto.AdopterData,
                Status: dto.Status
                );
        }
        public static AdoptionDTO ToDTO(this AdoptionDTO adoption)
        {
            return new AdoptionDTO
                (
                AdoptedCat: adoption.AdoptedCat,
                AdoptionDate: adoption.AdoptionDate,
                AdopterData: adoption.AdopterData,
                Status: adoption.Status
                );
        }
    }
}
