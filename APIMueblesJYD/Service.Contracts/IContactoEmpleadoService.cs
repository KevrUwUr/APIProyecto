﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactoEmpleadoService
    {
        IEnumerable<ContactoEmpleadoDTO> GetAllEmployeeContacts(bool trackChanges);
        ContactoEmpleadoDTO GetEmployeeContact(Guid Id, bool trackChanges);
    }
}
