using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmpleadoRepository : RepositoryBase<EmpleadoDTO>, IEmpleadoRepository
    {
        public EmpleadoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<EmpleadoDTO> GetAllEmployees(bool trackChanges) =>
              FindAll(trackChanges)
                  .OrderBy(c => c.Nombres)
                  .ToList();

        public EmpleadoDTO GetEmployee(Guid IdEmpleado, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(IdEmpleado), trackChanges)
            .SingleOrDefault();

    }
}
