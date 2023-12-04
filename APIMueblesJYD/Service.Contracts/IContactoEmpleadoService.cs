using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactoEmpleadoService
    {
        IEnumerable<ContactoEmpleadoDTO> GetAllEmployeeContacts(bool trackChanges);
        ContactoEmpleadoDTO GetEmployeeContact(Guid Id, bool trackChanges);
        IEnumerable<ContactoEmpleadoDTO> GetAllContactEmployeesForEmployee(Guid empleadoId, bool trackChanges);
        ContactoEmpleadoDTO GetContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges);
        ContactoEmpleadoDTO CreateContactEmployeeForEmployee(Guid empleadoId, ContactoEmpleadoForCreationDTO contactoEmpForCreation, bool trackChanges);
        void DeleteContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges);
        void UpdateContactEmployeeForEmployee(Guid empleadoId, Guid id,
            ContactoEmpleadoForUpdateDTO contactoEmpForUpdate, bool empTrackChanges, bool contEmpTrackChanges);
        (ContactoEmpleadoForUpdateDTO contEmpToPatch, ContactoEmpleado contEmpEntity) GetContactoEmpleadoForPatch
            (Guid empleadoId, Guid id, bool empTrackChanges, bool contEmpTrackChanges);
        void SaveChangesForPatch(ContactoEmpleadoForUpdateDTO contEmpToPatch, ContactoEmpleado contEmpEntity);
    }
}
