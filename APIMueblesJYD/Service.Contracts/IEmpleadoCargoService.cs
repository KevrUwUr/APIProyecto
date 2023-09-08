using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmpleadoCargoService
    {
        IEnumerable<EmpleadoCargoDTO> GetAllEmployeeJobs(bool trackChanges);
        EmpleadoCargoDTO GetEmployeeJob(Guid EmpleadoCargoId, bool trackChanges);
        EmpleadoCargoDTO GetByCargo(Guid CargoId,Guid EmpleadoCargoId, bool trackChanges);
        EmpleadoCargoDTO GetByEmployee(Guid EmpleadoId, Guid EmpleadoCargoId, bool trackChanges);
        EmpleadoCargoDTO CreateEmployeeJobForCargoEmployee(Guid CargoId, Guid EmpleadoId, EmpleadoCargoForCreationDTO employeeForCreation, bool trackChanges);
        IEnumerable<EmpleadoCargoDTO> GetByIds(IEnumerable<Guid> EmpleadoCargoId, bool trackChanges);
        void DeleteEmployeeJob(Guid EmpleadoCargoId, bool trackChanges);
        void UpdateEmployeeJob(Guid EmpleadoCargoId, EmpleadoCargoForUpdateDTO empleadoCargoForUpdate, bool trackChanges);
    }
}
