using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactoEmpleadoRepository : RepositoryBase<ContactoEmpleado>, IContactoEmpleadoRepository
    {
        public ContactoEmpleadoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<ContactoEmpleado> GetAllEmployeesContacts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Empleado)
            .ToList();

        public ContactoEmpleado GetEmployeeContact(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.IdContactoEmpleado.Equals(Id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<ContactoEmpleado> GetAllContactEmployeesForEmployee(Guid empleadoId, bool trackChanges) =>
            FindByCondition(e => e.EmpleadoId.Equals(empleadoId), trackChanges)
            .OrderBy(e => e.Empleado)
            .ToList();

        public ContactoEmpleado GetContactEmployeeForEmployee(Guid empleadoId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.EmpleadoId.Equals(empleadoId) && e.IdContactoEmpleado == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateContactEmployeeForEmployee(Guid empleadoId, ContactoEmpleado contEmp)
        {
            contEmp.EmpleadoId = empleadoId;
            Create(contEmp);
        }

        public void DeleteContactEmployee(ContactoEmpleado contEmp) => Delete(contEmp);
    }
}
