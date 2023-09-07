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
        EmpleadoCargoDTO CreateEmployeeJob(EmpleadoCargoForCreationDTO empleadoCargo);

        IEnumerable<EmpleadoCargoDTO> GetByIds(IEnumerable<Guid> EmpleadoCargoId, bool trackChanges);

        (IEnumerable<EmpleadoCargoDTO> empleadoCargos, string ids) CreateEmployeeJobCollection
                (IEnumerable<EmpleadoCargoForCreationDTO> cargoCollection);

        void DeleteEmployeeJob(Guid EmpleadoCargoId, bool trackChanges);

        void UpdateEmployeeJob(Guid EmpleadoCargoId, EmpleadoCargoForUpdateDTO empleadoCargoForUpdate, bool trackChanges);
    }
}
