using System;
using Application.Dto;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class EmailMapper
    {
        public static Email ToEntity(this EmailDTO dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Email(dto.value);
        }

        public static EmailDTO ToDTO(this Email email)
        {
            if (email is null) throw new ArgumentNullException(nameof(email));
            return new EmailDTO { value = email.Value };
        }
    }
}