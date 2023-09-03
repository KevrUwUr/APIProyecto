using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmpleadoRepository : RepositoryBase<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Empleado> GetAllEmployees(bool trackChanges) =>
              FindAll(trackChanges)
                  .OrderBy(c => c.Nombres)
                  .ToList();

        public Empleado GetEmployee(Guid IdEmpleado, bool trackChanges) =>
            FindByCondition(c => c.IdEmpleado.Equals(IdEmpleado), trackChanges)
            .SingleOrDefault();

    }
}
