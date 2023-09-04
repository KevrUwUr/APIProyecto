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
    public class EmpleadoCargoRepository : RepositoryBase<EmpleadoCargoDTO>, IEmpleadoCargoRepository
    {
        public EmpleadoCargoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<EmpleadoCargoDTO> GetAllEmployeeJobs(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NumeroContrato)
                .ToList();

        public EmpleadoCargoDTO GetEmployeeJob(int NumeroContrato, bool trackChanges) =>
            FindByCondition(c => c.NumeroContrato.Equals(NumeroContrato), trackChanges)
            .SingleOrDefault();

    }
}
