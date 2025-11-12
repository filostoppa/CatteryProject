using Domain.Model.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly List<Adoption> _adoptions;
        private readonly ICatteryRepository _repository;

        public AdoptionService(ICatteryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _adoptions = new List<Adoption>();
            LoadFromRepository();
        }

        private void LoadFromRepository()
        {
            var adoptions = _repository.LoadAdoptions();
            _adoptions.Clear();
            _adoptions.AddRange(adoptions);
        }

        private void SaveToRepository()
        {
            _repository.SaveAdoptions(_adoptions);
        }

        public Adoption AddAdoption(Adoption adoption)
        {
            if (adoption == null)
            {
                throw new ArgumentNullException(nameof(adoption));
            }

            _adoptions.Add(adoption);
            SaveToRepository();
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
            SaveToRepository();
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