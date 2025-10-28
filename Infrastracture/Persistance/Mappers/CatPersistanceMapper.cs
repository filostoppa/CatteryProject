using Application.Dto;
using Domain.Model.Entities;
using Infrastracture.Persistance.DTO;
using System;

namespace Infrastracture.Persistance.Mappers
{
    internal static class CatPersistanceMapper
    {
        // Converte un oggetto Cat in CatPersistanceDTO per salvarlo
        public static CatPersistanceDTO ToPersistanceDTO(this Cat cat)
        {
            if (cat == null)
            {
                throw new ArgumentNullException(nameof(cat));
            }

            return new CatPersistanceDTO(
                Name: cat.Name,
                Breed: cat.Breed,
                IsMale: cat.IsMale,
                BirthDate: cat.BirthDate,
                DepartureDate: cat.DepartureDate,
                ArrivalDate: cat.ArrivalDate,
                Description: cat.Description
            );
        }

        // Converte un CatPersistanceDTO in un oggetto Cat
        public static Cat ToEntity(this CatPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Cat(
                name: dto.Name,
                breed: dto.Breed,
                ismale: dto.IsMale,
                arrivalDate: dto.ArrivalDate,
                departureDate: dto.DepartureDate,
                birthDate: dto.BirthDate,
                description: dto.Description
            );
        }

        // Converte un CatPersistanceDTO in CatDTO per l'applicazione
        public static Application.Dto.CatDTO ToDTO(this CatPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Application.Dto.CatDTO(
                Name: dto.Name,
                Breed: dto.Breed,
                IsMale: dto.IsMale,
                BirthDate: dto.BirthDate,
                DepartureDate: dto.DepartureDate,
                ArrivalDate: dto.ArrivalDate,
                Description: dto.Description
            );
        }

        // Converte un CatDTO in CatPersistanceDTO per salvarlo
        public static CatPersistanceDTO ToPersistanceDTO(this Application.Dto.CatDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new CatPersistanceDTO(
                Name: dto.Name,
                Breed: dto.Breed,
                IsMale: dto.IsMale,
                BirthDate: dto.BirthDate,
                DepartureDate: dto.DepartureDate,
                ArrivalDate: dto.ArrivalDate,
                Description: dto.Description
            );
        }
    }
}