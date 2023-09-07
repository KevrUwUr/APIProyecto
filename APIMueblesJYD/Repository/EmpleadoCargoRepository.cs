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
    public class EmpleadoCargoRepository : RepositoryBase<EmpleadoCargo>, IEmpleadoCargoRepository
    {
        public EmpleadoCargoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<EmpleadoCargo> GetAllEmployeeJobs(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.EmpleadoCargoId)
                .ToList();

        public EmpleadoCargo GetEmployeeJob(Guid EmpleadoCargoId, bool trackChanges) =>
            FindByCondition(c => c.EmpleadoCargoId.Equals(EmpleadoCargoId), trackChanges)
            .SingleOrDefault();

        public void CreateEmployeeJob(EmpleadoCargo empleadoCargo) => Create(empleadoCargo);

        public IEnumerable<EmpleadoCargo> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.EmpleadoCargoId), trackChanges);


        public void DeleteEmployeeJob(EmpleadoCargo empleadoCargo) => Delete(empleadoCargo);

    }
}
