﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IContactoUsuarioService
    {
        IEnumerable<ContactoUsuarioDTO> GetAllUserContacts(bool trackChanges);
        ContactoUsuarioDTO GetUserContact(Guid Id, bool trackChanges);
    }
}
