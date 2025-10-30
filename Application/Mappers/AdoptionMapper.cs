using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        // Converte da DTO (application) a entità di dominio Adoption
        public static Adoption ToEntity(this AdoptionDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.AdoptedCat == null) throw new ArgumentNullException(nameof(dto.AdoptedCat));
            if (dto.AdopterData == null) throw new ArgumentNullException(nameof(dto.AdopterData));

            // Converte cat e adopter con i mapper esistenti
            Cat catEntity = CatMapper.ToEntity(dto.AdoptedCat);
            Adopter adopterEntity = AdopterMapper.ToEntity(dto.AdopterData);

            Adoption adoption = new Adoption(catEntity, dto.AdoptionDate, adopterEntity);

            // dto.Status: true = Completed, false = Cancelled
            if (dto.Status == false)
            {
                adoption.CancelAdoption();
            }

            return adoption;
        }

        // Converte da entità di dominio Adoption a DTO (application)
        public static AdoptionDTO ToDTO(this Adoption adoption)
        {
            if (adoption == null) throw new ArgumentNullException(nameof(adoption));

            Application.Dto.CatDTO catDto = adoption.AdoptedCat.ToDTO();
            Application.Dto.AdopterDTO adopterDto = adoption.AdopterData.ToDTO();
            bool statusBool = adoption.Status == Adoption.AdoptionStatus.Completed;

            return new AdoptionDTO(catDto, adoption.AdoptionDate, adopterDto, statusBool);
        }
    }
}
