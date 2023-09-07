using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
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
            FindByCondition(c => c.EmpleadoId.Equals(IdEmpleado), trackChanges)
            .SingleOrDefault();

        public void CreateEmployee(Empleado empleado) => Create(empleado);

        public IEnumerable<Empleado> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.EmpleadoId), trackChanges);

        public void DeleteEmployee(Empleado empleado) => Delete(empleado);


    }
}
