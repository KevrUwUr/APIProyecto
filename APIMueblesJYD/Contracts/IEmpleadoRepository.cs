using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmpleadoRepository
    {
        IEnumerable<Empleado> GetAllEmployees(bool trackChanges);
        Empleado GetEmployee(Guid employeeId, bool trackChanges);
        void CreateEmployee(Empleado employee);
        IEnumerable<Empleado> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteEmployee(Empleado employee);


    }
}
