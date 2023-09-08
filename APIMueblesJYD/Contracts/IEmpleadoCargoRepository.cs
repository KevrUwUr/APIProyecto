using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmpleadoCargoRepository
    {
        IEnumerable<EmpleadoCargo> GetAllEmployeeJobs(bool trackChanges);
        EmpleadoCargo GetEmployeeJob(Guid EmpleadoCargoId, bool trackChanges);
        IEnumerable<EmpleadoCargo> GetForCargo(Guid CargoId, bool trackChanges);
        IEnumerable<EmpleadoCargo> GetForEmployee(Guid EmpleadoId, bool trackChanges);
        EmpleadoCargo GetEmployeeJobByCargo(Guid CargoId,Guid Id, bool trackChanges);
        EmpleadoCargo GetEmployeeJodByEmployee(Guid EmpleadoId, Guid Id,  bool trackChanges);
        void CreateEmployeeJobForCargoEmployee(Guid CargoId, Guid EmpleadoId, EmpleadoCargo employeeEntity);
        IEnumerable<EmpleadoCargo> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteEmployeeJob(EmpleadoCargo employeeJob);
    }
}
