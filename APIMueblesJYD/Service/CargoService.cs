using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public IEnumerable<CargoDTO> GetAllCargos(bool trackChanges)
        {
            var cargos = _repository.Cargo.GetAllCargos(trackChanges);
            var cargosDTO = _mapper.Map<IEnumerable<CargoDTO>>(cargos);

            return cargosDTO;
        }

        public CargoDTO GetCargo(Guid Id, bool trackChanges)
        {
            var cargo = _repository.Cargo.GetCargo(Id, trackChanges);
            if (cargo == null)
            {
                throw new CargoNotFoundException(Id);
            }

            var cargoDTO = _mapper.Map<CargoDTO>(cargo);
            return cargoDTO;
        }

        public CargoDTO CreateCargo(CargoForCreationDTO cargo)
        {
            var cargoEntity = _mapper.Map<Cargo>(cargo);

            _repository.Cargo.CreateCargo(cargoEntity);
            _repository.Save();

            var cargoToReturn = _mapper.Map<CargoDTO>(cargoEntity);

            return cargoToReturn;
        }

        public IEnumerable<CargoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var cargoEntities = _repository.Cargo.GetByIds(ids, trackChanges);

            if (ids.Count() != cargoEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var cargosToReturn = _mapper.Map<IEnumerable<CargoDTO>>(cargoEntities);

            return cargosToReturn;

        }

        public (IEnumerable<CargoDTO> cargos, string ids) CreateCargoCollection
            (IEnumerable<CargoForCreationDTO> cargoCollection)
        {
            if (cargoCollection == null)
                throw new CargoCollectionBadRequest();

            var cargoEntities = _mapper.Map<IEnumerable<Cargo>>(cargoCollection);
            foreach (var cargo in cargoEntities)
            {
                _repository.Cargo.CreateCargo(cargo);
            }

            _repository.Save();

            var cargoCollectionToReturn = _mapper.Map<IEnumerable<CargoDTO>>(cargoEntities);

            var ids = string.Join(",", cargoCollectionToReturn.Select(c => c.Id));

            return (cargos: cargoCollectionToReturn, ids: ids);

        }

        public void DeleteCargo(Guid cargoId, bool trackChanges)
        {
            var cargo = _repository.Cargo.GetCargo(cargoId, trackChanges);
            if (cargo == null)
            {
                throw new CargoNotFoundException(cargoId);
            }

            _repository.Cargo.DeleteCargo(cargo);
            _repository.Save();

        }

        public void UpdateCargo(Guid cargoId, CargoForUpdateDTO cargoForUpdate, bool trackChanches)
        {
            var cargoEntity = _repository.Cargo.GetCargo(cargoId, trackChanches);

            if (cargoEntity == null)
            {
                throw new CargoNotFoundException(cargoId);
            }

            _mapper.Map(cargoForUpdate, cargoEntity);

            _repository.Save();

        }
    }
}