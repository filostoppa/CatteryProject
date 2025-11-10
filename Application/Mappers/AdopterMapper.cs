using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public static Adopter ToEntity(this AdopterDTO dto)
        {
            return new Adopter
                (
                firstName: dto.FirstName,
                lastName: dto.LastName,
                address: new Email(dto.Address),
                notes: dto.Notes,
                phone: new PhoneNumber (dto.Phone),
                fiscalCode: new FiscalCode(dto.FiscalCode),
                city: dto.City,
                cityCap: new Cap (dto.CityCap)
                );
        }
        public static AdopterDTO ToDTO(this Adopter adopter)
        {
            return new AdopterDTO
                (
                FirstName: adopter.FirstName,
                LastName: adopter.LastName,
                Address: adopter.Address.ToString(),
                Notes: adopter.Notes,
                Phone: adopter.Phone.ToString(),
                FiscalCode: adopter.FiscalCode.ToString(),
                City: adopter.City,
                CityCap: adopter.CityCap.ToString()
                );
        }
    }
}