using AutoMapper;
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

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger
            , IMapper mapper)
        {
            _cargoService = new Lazy<ICargoService>(() => 
            new CargoService(repositoryManager, logger, mapper));
        }
        public ICargoService CargoService => _cargoService.Value;
    }
}
