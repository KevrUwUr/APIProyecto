﻿using Entities.Models;
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
        EmpleadoCargo GetEmployeeJob(int NumeroContrato, bool trackChanges);
    }
}
