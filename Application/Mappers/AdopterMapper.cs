using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public Adopter ToEntity(CatDTO dto)
        {
            Adopter adopter = new Adopter
                (

                );
            return adopter;
        }
    }
}
