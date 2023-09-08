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
        ContactoEmpleado GetEmployeeContact(Guid IdContactoEmpleado, bool trackChanges);
        //void CreateEmployeeContact(ContactoEmpleado contactoEmpleado);
        //IEnumerable<ContactoEmpleado>GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        //void DeleteEmployeeContact(ContactoEmpleado contactoEmpleado);
    }
}
