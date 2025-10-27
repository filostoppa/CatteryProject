using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToEntity(CatDTO dto)
        {
            return new Cat
                (
                name: dto.Name,
                breed: dto.Breed,
                ismale: dto.IsMale,
                arrivalDate: dto.ArrivalDate,
                departureDate: dto.DepartureDate,
                birthDate: dto.BirthDate,
                description: dto.Description
                );
        }
        public static CatDTO ToDTO(this Cat cat)
        {
            return new CatDTO
                (
                Name: cat.Name,
                Breed: cat.Breed,
                IsMale: cat.IsMale,
                ArrivalDate: cat.ArrivalDate,
                DepartureDate: cat.DepartureDate,
                BirthDate: cat.BirthDate,
                Description: cat.Description
                );
        } 
    }
}
