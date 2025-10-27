﻿using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDTO
    (
        
        string? FirstName,
        string? LastName,
        string? Address,
        string? Phone,
        string? FiscalCode, 
        string? City, 
        string? CityCap 
    );
}
