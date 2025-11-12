using Application.Interfaces;
using System;

namespace Application.UseCases
{
    public class ServiceManager
    {
        private static ServiceManager? _instance;
        private static readonly object _lock = new object();

        public CatService CatService { get; private set; }
        public AdopterService AdopterService { get; private set; }
        public AdoptionService AdoptionService { get; private set; }

        private ICatteryRepository _repository;

        private ServiceManager(ICatteryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            CatService = new CatService(_repository);
            AdopterService = new AdopterService(_repository);
            AdoptionService = new AdoptionService(_repository);
        }

        public static void Initialize(ICatteryRepository repository)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ServiceManager(repository);
                    }
                }
            }
        }

        public static ServiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("ServiceManager non è stato inizializzato. Chiama Initialize() prima.");
                }
                return _instance;
            }
        }

        public void ReloadAllData()
        {
            CatService = new CatService(_repository);
            AdopterService = new AdopterService(_repository);
            AdoptionService = new AdoptionService(_repository);
        }
    }
}