using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmpleadoService
    {
        IEnumerable<EmpleadoDTO> GetEmployees(bool trackChanges);
        EmpleadoDTO GetEmployee(int Id, bool trackChanges);
    }
}
