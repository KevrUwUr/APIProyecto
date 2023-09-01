﻿using Entities.Models;
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
        IEnumerable<EmpleadoDTO> GetEmployeeJobs(bool trackChanges);
        EmpleadoDTO GetEmployeeJob(int numeroContrato, bool trackChanges);
    }
}
