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
    internal sealed class EmpleadoService : IEmpleadoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmpleadoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmpleadoDTO> GetAllEmployees(bool trackChanges)
        {
            var empleado = _repository.Empleado.GetAllEmployees(trackChanges);
            var empleadoDTO = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleado);

            return empleadoDTO;
        }

        public EmpleadoDTO GetEmployee(Guid Id, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(Id, trackChanges);
            if(empleado == null)
            {
                throw new EmpleadoNotFoundException(Id);
            }

            var empleadoDTO = _mapper.Map<EmpleadoDTO>(empleado);
            return empleadoDTO;
        }






        public EmpleadoDTO CreateEmployee(EmpleadoForCreationDTO empleado)
        {
            var empleadoEntity = _mapper.Map<Empleado>(empleado);

            _repository.Empleado.CreateEmployee(empleadoEntity);
            _repository.Save();

            var empleadoToReturn = _mapper.Map<EmpleadoDTO>(empleadoEntity);

            return empleadoToReturn;
        }

        public IEnumerable<EmpleadoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null)
                throw new IdParametersBadRequestException();

            var empleadoEntities = _repository.Empleado.GetByIds(ids, trackChanges);

            if (ids.Count() != empleadoEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var empleadosToReturn = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleadoEntities);

            return empleadosToReturn;

        }

        public (IEnumerable<EmpleadoDTO> empleados, string ids) CreateEmployeeCollection
            (IEnumerable<EmpleadoForCreationDTO> empleadoCollection)
        {
            if (empleadoCollection == null)
                throw new EmpleadoCollectionBadRequest();

            var empleadoEntities = _mapper.Map<IEnumerable<Empleado>>(empleadoCollection);
            foreach (var empleado in empleadoEntities)
            {
                _repository.Empleado.CreateEmployee(empleado);
            }

            _repository.Save();

            var empleadoCollectionToReturn = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleadoEntities);

            var ids = string.Join(",", empleadoCollectionToReturn.Select(c => c.EmpleadoId));

            return (empleados: empleadoCollectionToReturn, ids: ids);

        }

        public void DeleteEmployee(Guid empleadoId, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, trackChanges);
            if (empleado == null)
            {
                throw new EmpleadoNotFoundException(empleadoId);
            }

            _repository.Empleado.DeleteEmployee(empleado);
            _repository.Save();

        }

        public void UpdateEmployee(Guid empleadoId, EmpleadoForUpdateDTO empleadoForUpdate, bool trackChanches)
        {
            var empleadoEntity = _repository.Empleado.GetEmployee(empleadoId, trackChanches);

            if (empleadoEntity == null)
            {
                throw new EmpleadoNotFoundException(empleadoId);
            }

            _mapper.Map(empleadoForUpdate, empleadoEntity);

            _repository.Save();

        }
    }
}