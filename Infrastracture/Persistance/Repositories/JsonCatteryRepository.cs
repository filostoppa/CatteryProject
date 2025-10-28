using Domain.Model.Entities;
using Infrastracture.Persistance.DTO;
using Infrastracture.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Infrastracture.Persistance.Repositories
{
    internal class JsonCatteryRepository
    {
        private readonly string _dataFolder;
        private readonly JsonSerializerOptions _serializerOptions;

        // Inizializza la cartella e le opzioni JSON
        public JsonCatteryRepository()
        {
            _dataFolder = "Data";
            _serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            if (!Directory.Exists(_dataFolder))
            {
                Directory.CreateDirectory(_dataFolder);
            }
        }

        // Salva i gatti in un file JSON
        public bool SaveCats(List<Cat> cats)
        {
            if (cats == null) throw new ArgumentNullException(nameof(cats));

            List<CatPersistanceDTO> dtoList = new List<CatPersistanceDTO>();
            foreach (Cat cat in cats)
            {
                dtoList.Add(CatPersistanceMapper.ToPersistanceDTO(cat));
            }

            string path = Path.Combine(_dataFolder, "cats.json");
            string json = JsonSerializer.Serialize(dtoList, _serializerOptions);
            File.WriteAllText(path, json);
            return true;
        }

        // Carica i gatti dal file JSON
        public List<Cat> LoadCats()
        {
            string path = Path.Combine(_dataFolder, "cats.json");
            List<Cat> result = new List<Cat>();

            if (!File.Exists(path))
            {
                return result;
            }

            string json = File.ReadAllText(path);
            List<CatPersistanceDTO>? dtoList = JsonSerializer.Deserialize<List<CatPersistanceDTO>>(json);

            if (dtoList == null) return result;

            foreach (CatPersistanceDTO dto in dtoList)
            {
                try
                {
                    result.Add(dto.ToEntity());
                }
                catch
                {
                    // Ignora errori
                }
            }

            return result;
        }

        // Salva gli adottanti in un file JSON
        public bool SaveAdopters(List<Adopter> adopters)
        {
            if (adopters == null) throw new ArgumentNullException(nameof(adopters));

            List<AdopterPersistanceDTO> dtoList = new List<AdopterPersistanceDTO>();
            foreach (Adopter adopter in adopters)
            {
                dtoList.Add(AdopterPersistanceMapper.ToPersistanceDTO(adopter));
            }

            string path = Path.Combine(_dataFolder, "adopters.json");
            string json = JsonSerializer.Serialize(dtoList, _serializerOptions);
            File.WriteAllText(path, json);
            return true;
        }

        // Carica gli adottanti dal file JSON
        public List<Adopter> LoadAdopters()
        {
            string path = Path.Combine(_dataFolder, "adopters.json");
            List<Adopter> result = new List<Adopter>();

            if (!File.Exists(path))
            {
                return result;
            }

            string json = File.ReadAllText(path);
            List<AdopterPersistanceDTO>? dtoList = JsonSerializer.Deserialize<List<AdopterPersistanceDTO>>(json);

            if (dtoList == null) return result;

            foreach (AdopterPersistanceDTO dto in dtoList)
            {
                try
                {
                    result.Add(dto.ToEntity());
                }
                catch
                {
                    // Ignora errori
                }
            }

            return result;
        }

        // Salva le adozioni in un file JSON
        public bool SaveAdoptions(List<Adoption> adoptions)
        {
            if (adoptions == null) throw new ArgumentNullException(nameof(adoptions));

            List<AdoptionPersistanceDTO> dtoList = new List<AdoptionPersistanceDTO>();
            foreach (Adoption adoption in adoptions)
            {
                dtoList.Add(adoption.ToPersistanceDTO());
            }

            string path = Path.Combine(_dataFolder, "adoptions.json");
            string json = JsonSerializer.Serialize(dtoList, _serializerOptions);
            File.WriteAllText(path, json);
            return true;
        }

        // Carica le adozioni dal file JSON
        public List<Adoption> LoadAdoptions()
        {
            string path = Path.Combine(_dataFolder, "adoptions.json");
            List<Adoption> result = new List<Adoption>();

            if (!File.Exists(path))
            {
                return result;
            }

            string json = File.ReadAllText(path);
            List<AdoptionPersistanceDTO>? dtoList = JsonSerializer.Deserialize<List<AdoptionPersistanceDTO>>(json);

            if (dtoList == null) return result;

            foreach (AdoptionPersistanceDTO dto in dtoList)
            {
                try
                {
                    result.Add(dto.ToEntity());
                }
                catch
                {
                    // Ignora errori
                }
            }

            return result;
        }
    }
}