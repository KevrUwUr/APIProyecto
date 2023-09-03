using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmpleadoCargoRepository : RepositoryBase<Empleado_Cargo>, IEmpleadoCargoRepository
    {
        public EmpleadoCargoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Empleado_Cargo> GetAllEmployeeJob(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NumeroContrato)
                .ToList();

        public Empleado_Cargo GetEmployeeJob(int NumeroContrato, bool trackChanges) =>
            FindByCondition(c => c.NumeroContrato.Equals(NumeroContrato), trackChanges)
            .SingleOrDefault();

    }
}
