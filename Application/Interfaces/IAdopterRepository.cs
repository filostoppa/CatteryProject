using Application.Dto;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    /// Interfaccia semplice per i casi d'uso relativi agli adopter
    /// Stile e firme coerenti con le altre interfacce del progetto
    public interface IAdopterRepository
    {
        // Aggiunge un adopter a partire da un DTO e ritorna il DTO creato
        void AddAdopter(AdopterDTO dto);

        // Restituisce tutti gli adopter come lista di DTO
        List<AdopterDTO> GetAllAdopters();

        // Recupera un adopter tramite il codice fiscale; ritorna null se non trovato
        AdopterDTO? GetByFiscalCode(string fiscalCode);

        // Cerca adopter per nome e cognome (entrambi opzionali)
        List<AdopterDTO> GetByName(string firstName, string lastName);

        // Rimuove un adopter identificato dal codice fiscale. Ritorna true se rimosso
        bool RemoveByFiscalCode(string fiscalCode);
    }
}