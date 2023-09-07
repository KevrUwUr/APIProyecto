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
    internal sealed class EmpleadoCargoService : IEmpleadoCargoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmpleadoCargoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmpleadoCargoDTO> GetAllEmployeeJobs(bool trackChanges)
        {
            var empleadoCargo = _repository.EmpleadoCargo.GetAllEmployeeJobs(trackChanges);
            var empleadoCargoDTO = _mapper.Map<IEnumerable<EmpleadoCargoDTO>>(empleadoCargo);

            return empleadoCargoDTO;
        }

        public EmpleadoCargoDTO GetEmployeeJob(Guid EmpleadoCargoId, bool trackChanges)
        {
            var empleadoCargo = _repository.EmpleadoCargo.GetEmployeeJob(EmpleadoCargoId, trackChanges);
            if (empleadoCargo == null)
            {
                throw new EmpleadoCargoNotFoundException(EmpleadoCargoId);
            }

            var empleadoCargoDTO = _mapper.Map<EmpleadoCargoDTO>(empleadoCargo);
            return empleadoCargoDTO;
        }

        public EmpleadoCargoDTO CreateEmployeeJob(EmpleadoCargoForCreationDTO empleadoCargo)
        {
            var empleadoCargoEntity = _mapper.Map<EmpleadoCargo>(empleadoCargo);

            _repository.EmpleadoCargo.CreateEmployeeJob(empleadoCargoEntity);
            _repository.Save();

            var empleadoCargoToReturn = _mapper.Map<EmpleadoCargoDTO>(empleadoCargoEntity);

            return empleadoCargoToReturn;
        }

        public IEnumerable<EmpleadoCargoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var empleadoCargoEntities = _repository.EmpleadoCargo.GetByIds(ids, trackChanges);

            if (ids.Count() != empleadoCargoEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var empleadoCargosToReturn = _mapper.Map<IEnumerable<EmpleadoCargoDTO>>(empleadoCargoEntities);

            return empleadoCargosToReturn;

        }










        public (IEnumerable<EmpleadoCargoDTO> empleadoCargos, string ids) CreateEmployeeJobCollection
            (IEnumerable<EmpleadoCargoForCreationDTO> empleadoCargoCollection)
        {
            if (empleadoCargoCollection == null)
                throw new CargoCollectionBadRequest();

            var empleadoCargoEntities = _mapper.Map<IEnumerable<EmpleadoCargo>>(empleadoCargoCollection);
            foreach (var empleadoCargo in empleadoCargoEntities)
            {
                _repository.EmpleadoCargo.CreateEmployeeJob(empleadoCargo);
            }

            _repository.Save();

            var empleadoCargoCollectionToReturn = _mapper.Map<IEnumerable<EmpleadoCargoDTO>>(empleadoCargoEntities);

            var ids = string.Join(",", empleadoCargoCollectionToReturn.Select(c => c.Id));

            return (empleadoCargos: empleadoCargoCollectionToReturn, ids: ids);

        }

        public void DeleteEmployeeJob(Guid empleadoId, bool trackChanges)
        {
            var empleadoCargo = _repository.EmpleadoCargo.GetEmployeeJob(empleadoId, trackChanges);
            if (empleadoCargo == null)
            {
                throw new EmpleadoCargoNotFoundException(empleadoId);
            }

            _repository.EmpleadoCargo.DeleteEmployeeJob(empleadoCargo);
            _repository.Save();

        }

        public void UpdateEmployeeJob(Guid empleadoId, EmpleadoCargoForUpdateDTO empleadoCargoForUpdate, bool trackChanches)
        {
            var empleadoCargoEntity = _repository.EmpleadoCargo.GetEmployeeJob(empleadoId, trackChanches);

            if (empleadoCargoEntity == null)
            {
                throw new CargoNotFoundException(empleadoId);
            }

            _mapper.Map(empleadoCargoForUpdate, empleadoCargoEntity);

            _repository.Save();

        }
    }
}