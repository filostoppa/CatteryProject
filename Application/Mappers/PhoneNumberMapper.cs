using System;
using Application.Dto;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class PhoneNumberMapper
    {
        public static PhoneNumber ToEntity(this PhoneNumberDTO dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new PhoneNumber(dto.value);
        }

        public static PhoneNumberDTO ToDTO(this PhoneNumber phone)
        {
            if (phone is null) throw new ArgumentNullException(nameof(phone));
            return new PhoneNumberDTO { value = phone.Value };
        }
    }
}