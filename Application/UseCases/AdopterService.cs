using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AdopterService
    {
        private readonly List<Adopter> _adopters;
        public AdopterService()
        {
            _adopters = new List<Adopter>();
        }
        public Adopter AddAdopter(Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter));
            }
            _adopters.Add(adopter);
            return adopter;
        }
        public List<Adopter> GetAllAdopters()
        {
            return new List<Adopter>(_adopters);
        }
        public Adopter? GetByFiscalCode(string fiscalCode)
        {
            fiscalCode = fiscalCode.ToUpper();
            if (string.IsNullOrWhiteSpace(fiscalCode))
            {
                throw new ArgumentException("Fiscal code is not valid", nameof(fiscalCode));
            }
            foreach (Adopter adopter in _adopters)
            {
                if (adopter.FiscalCode.Value.Equals(fiscalCode))
                {
                    return adopter;
                }
            }
            return null;
        }
        public Adopter? RemoveByFiscalCode(string fiscalCode)
        {
            fiscalCode = fiscalCode.ToUpper();
            if (string.IsNullOrWhiteSpace(fiscalCode))
            {
                throw new ArgumentException("Fiscal code is not valid", nameof(fiscalCode));
            }
            for (int i = 0; i < _adopters.Count; i++)
            {
                if (_adopters[i].FiscalCode.Value.Equals(fiscalCode))
                {
                    Adopter removedAdopter = _adopters[i];
                    _adopters.RemoveAt(i);
                    return removedAdopter;
                }
            }
            return null;
        }
    }
}
