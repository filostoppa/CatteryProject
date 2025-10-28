using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CatteryService
    {
        private readonly List<Cat> _cats;

        // Creo la lista dei gatti
        public CatteryService()
        {
            _cats = new List<Cat>();
        }

        // Aggiunge un gatto alla lista
        public CatDTO AddCat(CatDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            Cat cat = CatMapper.ToEntity(dto);
            _cats.Add(cat);
            return cat.ToDTO();
        }

        // Restituisce tutti i gatti come lista di DTO
        public List<CatDTO> GetAllCats()
        {
            List<CatDTO> result = new List<CatDTO>();
            foreach (Cat cat in _cats)
            {
                result.Add(cat.ToDTO());
            }
            return result;
        }

        // Cerca un gatto per ID
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

        // Trova i gatti senza data di uscita dal gattile
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

        // Aggiorna la data di uscita di un gatto
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
                    return true;
                }
            }
            return false;
        }

        // Rimuove un gatto dalla lista per ID
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
                    return true;
                }
            }
            return false;
        }
    }
}