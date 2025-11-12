using Domain.Model.Entities;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class AdopterService
    {
        private readonly List<Adopter> _adopters;
        private readonly ICatteryRepository _repository;

        public AdopterService(ICatteryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _adopters = new List<Adopter>();
            LoadFromRepository();
        }

        private void LoadFromRepository()
        {
            var adopters = _repository.LoadAdopters();
            _adopters.Clear();
            _adopters.AddRange(adopters);
        }

        private void SaveToRepository()
        {
            _repository.SaveAdopters(_adopters);
        }

        public Adopter AddAdopter(Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter));
            }

            _adopters.Add(adopter);
            SaveToRepository();
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
                    SaveToRepository();
                    return removedAdopter;
                }
            }
            return null;
        }

        public bool Remove(Adopter adopter)
        {
            if (adopter == null)
            {
                throw new ArgumentNullException(nameof(adopter));
            }

            bool removed = _adopters.Remove(adopter);
            if (removed)
            {
                SaveToRepository();
            }
            return removed;
        }
    }
}