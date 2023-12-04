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

        public IEnumerable<ContactoEmpleadoDTO> GetAllContactEmployeesForEmployee(Guid empleadoId, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, trackChanges);

            if (empleado is null)
            {
                throw new EmpleadoNotFoundException(empleadoId);
            }
            var contEmpsFromDb = _repository.ContactoEmpleado.GetAllContactEmployeesForEmployee(empleadoId, trackChanges);
            var contEmpsDTO = _mapper.Map<IEnumerable<ContactoEmpleadoDTO>>(contEmpsFromDb);

            return contEmpsDTO;
        }

        public ContactoEmpleadoDTO GetContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, trackChanges);
            if (empleado is null)
            {
                throw new EmpleadoNotFoundException(empleadoId);
            }
            var contEmpDb = _repository.ContactoEmpleado.GetContactEmployeeForEmployee(empleadoId, Id, trackChanges);
            if (contEmpDb is null)
            {
                throw new ContactoEmpleadoNotFoundException(Id);
            }
            var contEmp = _mapper.Map<ContactoEmpleadoDTO>(contEmpDb);
            return contEmp;
        }

        public ContactoEmpleadoDTO CreateContactEmployeeForEmployee(Guid empleadoId, ContactoEmpleadoForCreationDTO contEmpForCreation, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, trackChanges);
            if (empleado is null)
                throw new EmpleadoNotFoundException(empleadoId);

            var contEmpEntity = _mapper.Map<ContactoEmpleado>(contEmpForCreation);

            _repository.ContactoEmpleado.CreateContactEmployeeForEmployee(empleadoId, contEmpEntity);
            _repository.Save();

            var contEmpToReturn = _mapper.Map<ContactoEmpleadoDTO>(contEmpEntity);
            return contEmpToReturn;
        }

        public void DeleteContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, trackChanges);
            if (empleado is null)
                throw new EmpleadoNotFoundException(empleadoId);
            var contEmpForEmpleado = _repository.ContactoEmpleado.GetContactEmployeeForEmployee(empleadoId, Id,
            trackChanges);
            if (contEmpForEmpleado is null)
                throw new ContactoEmpleadoNotFoundException(Id);
            _repository.ContactoEmpleado.DeleteContactEmployee(contEmpForEmpleado);
            _repository.Save();
        }

        public void UpdateContactEmployeeForEmployee(Guid empleadoId, Guid id, ContactoEmpleadoForUpdateDTO contEmpForUpdate, bool empTrackChanges, bool contEmpTrackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, empTrackChanges);
            if (empleado is null)
            {
                throw new EmpleadoNotFoundException(empleadoId);
            }

            var contEmpEntity = _repository.ContactoEmpleado.GetContactEmployeeForEmployee(empleadoId, id, contEmpTrackChanges);
            if (contEmpEntity is null)
            {
                throw new ContactoEmpleadoNotFoundException(id);
            }

            _mapper.Map(contEmpForUpdate, contEmpEntity);
            _repository.Save();
        }

        public (ContactoEmpleadoForUpdateDTO contEmpToPatch, ContactoEmpleado contEmpEntity) GetContactoEmpleadoForPatch(Guid empleadoId, Guid id, bool empTrackChanges, bool contEmpTrackChanges)
        {
            var empleado = _repository.Empleado.GetEmployee(empleadoId, contEmpTrackChanges);
            if (empleado is null)
                throw new EmpleadoNotFoundException(empleadoId);

            var contEmpEntity = _repository.ContactoEmpleado.GetContactEmployeeForEmployee(empleadoId, id, contEmpTrackChanges);

            if (contEmpEntity is null)
                throw new ContactoEmpleadoNotFoundException(empleadoId);

            var contEmpToPatch = _mapper.Map<ContactoEmpleadoForUpdateDTO>(contEmpEntity);
            return (contEmpToPatch, contEmpEntity);
        }

        public void SaveChangesForPatch(ContactoEmpleadoForUpdateDTO contEmpToPatch, ContactoEmpleado contEmpEntity)
        {
            _mapper.Map(contEmpToPatch, contEmpEntity);
            _repository.Save();
        }
    }
}
