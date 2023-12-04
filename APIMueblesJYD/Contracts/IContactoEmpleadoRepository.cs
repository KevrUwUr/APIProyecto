using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IContactoEmpleadoRepository
    {
        IEnumerable<ContactoEmpleado> GetAllEmployeesContacts(bool trackChanges);
        ContactoEmpleado GetEmployeeContact(Guid employeeContactId, bool trackChanges);
        IEnumerable<ContactoEmpleado> GetAllContactEmployeesForEmployee(Guid empleadoId, bool trackChanges);
        ContactoEmpleado GetContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges);
        void CreateContactEmployeeForEmployee(Guid empleadoId, ContactoEmpleado contEmp);
        void DeleteContactEmployee(ContactoEmpleado contEmp);
    }
}
