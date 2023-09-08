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
                .OrderBy(c => c.NumeroContrato)
                .ToList();

        public EmpleadoCargo GetEmployeeJob(Guid EmpleadoCargoId, bool trackChanges) =>
            FindByCondition(c => c.EmpleadoCargoId.Equals(EmpleadoCargoId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<EmpleadoCargo> GetForCargo(Guid CargoId, bool trackChanges) =>
            FindByCondition(c => c.CargoId.Equals(CargoId),trackChanges)
            .OrderBy(c => c.NumeroContrato )
            .ToList();

        public IEnumerable<EmpleadoCargo> GetForEmployee(Guid EmpleadoId, bool trackChanges) =>
            FindByCondition(c => c.EmpleadoId.Equals(EmpleadoId), trackChanges)
            .OrderBy(c => c.NumeroContrato)
            .ToList();

        public EmpleadoCargo GetEmployeeJobByCargo(Guid CargoId, Guid Id, bool trackChanges) =>
            FindByCondition(c => c.CargoId.Equals(CargoId) && c.EmpleadoCargoId.Equals(Id), trackChanges)
            .SingleOrDefault();

        public EmpleadoCargo GetEmployeeJodByEmployee(Guid EmpleadoId, Guid Id, bool trackChanges) =>
            FindByCondition(c => c.EmpleadoId.Equals(EmpleadoId) && c.EmpleadoCargoId.Equals(Id), trackChanges)
            .SingleOrDefault();


        public void CreateEmployeeJobForCargoEmployee(Guid CargoId, Guid EmpleadoId, EmpleadoCargo employeeJob)
        {
            employeeJob.CargoId = CargoId;
            employeeJob.EmpleadoId = EmpleadoId;
            Create(employeeJob);
        }

        public IEnumerable<EmpleadoCargo> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.EmpleadoCargoId), trackChanges);


        public void DeleteEmployeeJob(EmpleadoCargo empleadoCargo) => Delete(empleadoCargo);

    }
}
