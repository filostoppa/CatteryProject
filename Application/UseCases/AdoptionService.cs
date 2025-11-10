using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Mappers;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly List<Adoption> _adoptions;
        public AdoptionService()
        {
            _adoptions = new List<Adoption>();
        }
        public Adoption AddAdoption(Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption));
            }
            _adoptions.Add(adoption);
            return adoption;
        }
        public List<Adoption> GetAllAdoptions()
        {
            return new List<Adoption>(_adoptions);
        }
        public Adoption RemoveAdoption(Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption));
            }
            _adoptions.Remove(adoption);
            return adoption;
        }
        public Adoption? GetByCatId(string catId)
        {
            if (string.IsNullOrWhiteSpace(catId))
            {
                throw new ArgumentException("Cat ID is not valid", nameof(catId));
            }
            foreach (Adoption adoption in _adoptions)
            {
                if (adoption.AdoptedCat.ID.Equals(catId))
                {
                    return adoption;
                }
            }
            return null;
        }

        public Adoption? GetByAdopterFiscalCode(string fiscalCode)
        {
            if (string.IsNullOrWhiteSpace(fiscalCode))
            {
                throw new ArgumentException("Fiscal code is not valid", nameof(fiscalCode));
            }
            foreach (Adoption adoption in _adoptions)
            {
                if (adoption.AdopterData.FiscalCode.Value.Equals(fiscalCode.ToUpper()))
                {
                    return adoption;
                }
            }
            return null;
        }
    }
}
