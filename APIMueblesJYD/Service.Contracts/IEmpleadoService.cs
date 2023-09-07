using Entities.Models;
using Shared.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoDTO> GetAllEmployees(bool trackChanges);
        EmpleadoDTO GetEmployee(Guid empleadoId, bool trackChanges);

        EmpleadoDTO CreateEmployee(EmpleadoForCreationDTO empleado);

        IEnumerable<EmpleadoDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        (IEnumerable<EmpleadoDTO> empleados, string ids) CreateEmployeeCollection
                (IEnumerable<EmpleadoForCreationDTO> empleadoCollection);

        void DeleteEmployee(Guid empleadoId, bool trackChanges);

        void UpdateEmployee(Guid empleadoId, EmpleadoForUpdateDTO empleadoForUpdate, bool trackChanges);
    }
}
