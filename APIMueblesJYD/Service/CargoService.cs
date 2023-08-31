using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CargoService : ICargoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CargoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CargoDto> GetAllCargos(bool trackChanges)
        {
            var cargos = _repository.Cargo.GetAllCargos(trackChanges);
            var cargosDto = _mapper.Map<IEnumerable<CargoDto>>(cargos);

            return cargosDto;
        }

        public CargoDto GetCargo(Guid cargoId, bool trackChanges)
        {
            var cargo = _repository.Cargo.GetCargo(cargoId, trackChanges);

            var cargoDto = _mapper.Map<CargoDto>(cargo);
            return cargoDto;
        }
    }
}
