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
    internal sealed class EmpleadoCargoService : IEmpleadoCargoRepository
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

        public IEnumerable<EmpleadoDTO> GetAllEmployeeJobs(bool trackChanges)
        {
            var empleadoCargo = _repository.EmpleadoCargo.GetAllEmployeeJobs(trackChanges);
            var empleadoCargoDTO = _mapper.Map<IEnumerable<EmpleadoDTO>>(empleadoCargo);

            return empleadoCargoDTO;
        }

        public EmpleadoDTO GetEmployeeJob(int NumeroContrato, bool trackChanges)
        {
            var empleadoCargo = _repository.EmpleadoCargo.GetEmployeeJob(NumeroContrato, trackChanges);
            if(empleadoCargo == null)
            {
                throw new EmpleadoCargoNotFoundException(NumeroContrato);
            }

            var empleadoCargoDTO = _mapper.Map<EmpleadoDTO>(empleadoCargo);
            return empleadoCargoDTO;
        }
    }
}
