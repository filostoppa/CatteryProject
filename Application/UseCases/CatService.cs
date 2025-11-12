using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.UseCases
{
    public class CatService
    {
        private readonly List<Cat> _cats;
        private readonly ICatteryRepository _repository;

        public CatService(ICatteryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cats = new List<Cat>();
            LoadFromRepository();
        }

        private void LoadFromRepository()
        {
            var cats = _repository.LoadCats();
            _cats.Clear();
            _cats.AddRange(cats);
        }

        private void SaveToRepository()
        {
            _repository.SaveCats(_cats);
        }

        public CatDTO AddCat(CatDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            Cat cat = CatMapper.ToEntity(dto);
            _cats.Add(cat);
            SaveToRepository();
            return cat.ToDTO();
        }

        public List<CatDTO> GetAllCats()
        {
            List<CatDTO> result = new List<CatDTO>();
            foreach (Cat cat in _cats)
            {
                result.Add(cat.ToDTO());
            }
            return result;
        }

        public CatDTO? GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id non valido", nameof(id));
            }

            foreach (Cat cat in _cats)
            {
                if (cat.ID == id)
                {
                    return cat.ToDTO();
                }
            }
            return null;
        }

        public List<CatDTO> GetAvailableCats()
        {
            List<CatDTO> result = new List<CatDTO>();
            foreach (Cat cat in _cats)
            {
                if (cat.DepartureDate == null)
                {
                    result.Add(cat.ToDTO());
                }
            }
            return result;
        }

        public bool UpdateDepartureDate(string id, DateOnly? departureDate)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id non valido", nameof(id));
            }

            for (int i = 0; i < _cats.Count; i++)
            {
                Cat cat = _cats[i];
                if (cat.ID == id)
                {
                    cat.UpdateDepartureDate(departureDate);
                    SaveToRepository();
                    return true;
                }
            }
            return false;
        }

        public bool RemoveById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id non valido", nameof(id));
            }

            for (int i = 0; i < _cats.Count; i++)
            {
                Cat cat = _cats[i];
                if (cat.ID == id)
                {
                    _cats.RemoveAt(i);
                    SaveToRepository();
                    return true;
                }
            }
            return false;
        }
    }
}