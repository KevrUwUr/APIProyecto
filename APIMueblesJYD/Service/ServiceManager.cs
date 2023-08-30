using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICargoService> _cargoService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _cargoService = new Lazy<ICargoService>(() => 
            new CargoService(repositoryManager, logger));
        }
        public ICargoService CargoService => _cargoService.Value;
    }
}
