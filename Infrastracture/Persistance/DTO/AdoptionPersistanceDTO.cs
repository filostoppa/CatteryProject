using System;
using Domain.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.DTO
{
    public record AdoptionPersistanceDTO
        (
        Cat cat,
        DateOnly adoptionDate,
        Adopter adopter,
        Adoption.AdoptionStatus status
        );
}
