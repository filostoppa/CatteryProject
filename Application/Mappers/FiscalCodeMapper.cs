using System;
using Application.Dto;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class FiscalCodeMapper
    {
        public static FiscalCode ToEntity(this FiscalCodeDTO dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new FiscalCode(dto.value);
        }

        public static FiscalCodeDTO ToDTO(this FiscalCode fiscalCode)
        {
            if (fiscalCode is null) throw new ArgumentNullException(nameof(fiscalCode));
            return new FiscalCodeDTO { value = fiscalCode.Value };
        }
    }
}