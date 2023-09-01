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
        IEnumerable<EmpleadoDTO> GetAllEmployeeJobs(bool trackChanges);
        EmpleadoDTO GetEmployeeJob(int NumeroContrato, bool trackChanges);
    }
}
