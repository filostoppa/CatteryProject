using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using Infrastracture.Persistance.DTO;
using System;

namespace Infrastracture.Persistance.Mappers
{
    internal static class AdoptionPersistanceMapper
    {
        // Converte un'adozione in AdoptionPersistanceDTO per salvarla
        public static AdoptionPersistanceDTO ToPersistanceDTO(this Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption));
            }

            return new AdoptionPersistanceDTO
                (
                cat: adoption.AdoptedCat,
                adoptionDate: adoption.AdoptionDate,
                adopter: adoption.AdopterData,
                status: adoption.Status
                );
        }

        // Converte un AdoptionPersistanceDTO in un oggetto Adoption
        public static Adoption ToEntity(this AdoptionPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Adoption(dto.cat, dto.adoptionDate, dto.adopter);
        }

        // Converte un AdoptionPersistanceDTO in AdoptionDTO per l'applicazione
        public static Application.Dto.AdoptionDTO ToDTO(this AdoptionPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            // Converte lo status enum in bool dove true = Completed e false = Cancelled

            bool statusBool = dto.status == Adoption.AdoptionStatus.Completed;

            // Converte cat e adopter in DTO usando i mapper dell'application
            CatDTO adoptedCatDto = Application.Mappers.CatMapper.ToDTO(dto.cat);
            AdopterDTO adopterDto = Application.Mappers.AdopterMapper.ToDTO(dto.adopter);

            return new Application.Dto.AdoptionDTO(adoptedCatDto, dto.adoptionDate, adopterDto, statusBool);
        }

        // Converte un AdoptionDTO in AdoptionPersistanceDTO per salvarlo
        public static AdoptionPersistanceDTO ToPersistanceDTO(this Application.Dto.AdoptionDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (dto.AdoptedCat == null)
            {
                throw new ArgumentNullException(nameof(dto.AdoptedCat), "AdoptedCat non può essere null per la persistenza.");
            }

            if (dto.AdopterData == null)
            {
                throw new ArgumentNullException(nameof(dto.AdopterData), "AdopterData non può essere null per la persistenza.");
            }

            // Converte i DTO dell'application in entità di dominio usando i mapper
            Cat catEntity = Application.Mappers.CatMapper.ToEntity(dto.AdoptedCat);
            Adopter adopterEntity = Application.Mappers.AdopterMapper.ToEntity(dto.AdopterData);
            Adoption.AdoptionStatus statusEnum = dto.Status ? Adoption.AdoptionStatus.Completed : Adoption.AdoptionStatus.Cancelled;

            return new AdoptionPersistanceDTO(catEntity, dto.AdoptionDate, adopterEntity, statusEnum);
        }
    }
}