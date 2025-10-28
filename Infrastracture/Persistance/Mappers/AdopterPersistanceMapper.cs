using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using Infrastracture.Persistance.DTO;
using System;

namespace Infrastracture.Persistance.Mappers
{
    internal static class AdopterPersistanceMapper
    {
        // Converte un Adopter in AdopterPersistanceDTO per salvare i dati
        public static AdopterPersistanceDTO ToPersistanceDTO(this Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter));
            }

            return new AdopterPersistanceDTO
                (
                FirstName: adopter.FirstName,
                LastName: adopter.LastName,
                Address: adopter.Address.ToString(),
                Phone: adopter.Phone.ToString(),
                FiscalCode: adopter.FiscalCode.ToString(),
                City: adopter.City,
                CityCap: adopter.CityCap.ToString()
                );
        }

        // Converte un AdopterPersistanceDTO in un oggetto Adopter
        public static Adopter ToEntity(this AdopterPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            Email email = new Email(dto.Address);
            PhoneNumber phone = new PhoneNumber(dto.Phone);
            FiscalCode fiscal = new FiscalCode(dto.FiscalCode);
            Cap cap = new Cap(dto.CityCap);

            return new Adopter(dto.FirstName, dto.LastName, email, phone, fiscal, dto.City, cap);
        }

        // Converte un AdopterPersistanceDTO in AdopterDTO
        public static AdopterDTO ToDTO(this AdopterPersistanceDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new AdopterDTO(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.FiscalCode, dto.City, dto.CityCap);
        }

        // Converte un AdopterDTO in AdopterPersistanceDTO
        public static AdopterPersistanceDTO ToPersistanceDTO(this AdopterDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new AdopterPersistanceDTO(dto.FirstName, dto.LastName, dto.Address, dto.Phone, dto.FiscalCode, dto.City, dto.CityCap);
        }
    }
}