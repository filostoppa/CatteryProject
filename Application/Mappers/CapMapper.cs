using System;
using Application.Dto;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class CapMapper
    {
        public static Cap ToEntity(this CapDTO dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            return new Cap(dto.value);
        }

        public static CapDTO ToDTO(this Cap cap)
        {
            if (cap is null) throw new ArgumentNullException(nameof(cap));
            return new CapDTO { value = cap.Value };
        }
    }
}