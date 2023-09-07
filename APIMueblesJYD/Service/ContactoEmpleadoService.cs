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
    internal sealed class ContactoEmpleadoService : IContactoEmpleadoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ContactoEmpleadoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ContactoEmpleadoDTO> GetAllEmployeeContacts(bool trackChanges)
        {
            var contactoEmpleado = _repository.ContactoEmpleado.GetAllEmployeesContacts(trackChanges);
            var contactoEmpleadoDTO = _mapper.Map<IEnumerable<ContactoEmpleadoDTO>>(contactoEmpleado);

            return contactoEmpleadoDTO;
        }

        public ContactoEmpleadoDTO GetEmployeeContact(Guid Id, bool trackChanges)
        {
            var contactoEmpleado = _repository.ContactoEmpleado.GetEmployeeContact(Id, trackChanges);
            if(contactoEmpleado == null)
            {
                throw new ContactoEmpleadoNotFoundException(Id);
            }

            var contactoEmpleadoDTO = _mapper.Map<ContactoEmpleadoDTO>(contactoEmpleado);
            return contactoEmpleadoDTO;
        }
    }
}
