using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record CatDTO
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
