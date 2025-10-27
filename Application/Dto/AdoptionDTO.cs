using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdoptionDTO
    (
        CatDTO? AdoptedCat,
        DateOnly AdoptionDate,
        AdopterDTO? AdopterData,
        bool Status
    );
}
