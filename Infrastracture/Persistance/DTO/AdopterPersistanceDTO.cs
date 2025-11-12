using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistance.DTO
{
    public record AdopterPersistanceDTO
        (
        string? FirstName,
        string? LastName,
        string? Address,
        string? Notes,
        string? Phone,
        string? FiscalCode,
        string? City,
        string? CityCap
        );
}