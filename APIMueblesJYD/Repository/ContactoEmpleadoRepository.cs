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

        public ContactoEmpleado GetEmployeeContact(int Id, bool trackChanges) =>
            FindByCondition(c => c.IdContactoEmpleado.Equals(Id), trackChanges)
            .SingleOrDefault();
    }
}
