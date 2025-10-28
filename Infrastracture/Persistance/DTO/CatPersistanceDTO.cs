using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.DTO
{
    public record CatPersistanceDTO
        (
        string? Name,
        string? Breed,
        bool IsMale,
        DateOnly? BirthDate,
        DateOnly? DepartureDate,
        DateOnly ArrivalDate,
        string? Description
        );
}
