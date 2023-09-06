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
    }
}
