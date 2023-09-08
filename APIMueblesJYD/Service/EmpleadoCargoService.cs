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

        public EmpleadoCargoDTO GetByCargo(Guid CargoId, Guid EmpleadoCargoId, bool trackChanges)
        {
            var cargo = _repository.Cargo.GetCargo(CargoId, trackChanges);
            if (cargo == null)
                throw new CargoNotFoundException(CargoId);

            var empCargDB = _repository.EmpleadoCargo.GetEmployeeJobByCargo(CargoId, EmpleadoCargoId, trackChanges);
            if (empCargDB == null)
                throw new EmpleadoCargoNotFoundException(EmpleadoCargoId);

            var empleadoCargo = _mapper.Map<EmpleadoCargoDTO>(empCargDB);
            return empleadoCargo;
        }

        public EmpleadoCargoDTO GetByEmployee(Guid EmpleadoId, Guid EmpleadoCargoId, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(EmpleadoId, trackChanges);
            if (empleado == null)
                throw new EmpleadoNotFoundException(EmpleadoId);

            var empCargDB = _repository.EmpleadoCargo.GetEmployeeJobByCargo(EmpleadoId, EmpleadoCargoId, trackChanges);
            if (empCargDB == null)
                throw new EmpleadoCargoNotFoundException(EmpleadoCargoId);

            var empleadoCargo = _mapper.Map<EmpleadoCargoDTO>(empCargDB);
            return empleadoCargo;
        }


        public EmpleadoCargoDTO CreateEmployeeJobForCargoEmployee(Guid CargoId, Guid EmpleadoId, EmpleadoCargoForCreationDTO employeeCargoForCreation, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(EmpleadoId, trackChanges);
            if (empleado == null)
                throw new EmpleadoNotFoundException(EmpleadoId);

            var cargo = _repository.Cargo.GetCargo(CargoId, trackChanges);
            if (cargo == null)
                throw new CargoNotFoundException(CargoId);

            var employeeEntity = _mapper.Map<EmpleadoCargo>(employeeCargoForCreation);

            _repository.EmpleadoCargo.CreateEmployeeJobForCargoEmployee(CargoId, EmpleadoId, employeeEntity);
            _repository.Save();

            var empleadoCargoToReturn = _mapper.Map<EmpleadoCargoDTO>(employeeEntity);

            return empleadoCargoToReturn;
        }
    }
}