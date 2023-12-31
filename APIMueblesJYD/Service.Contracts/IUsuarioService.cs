﻿using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDTO> GetAllUsers(bool trackChanges);
        UsuarioDTO GetUser(Guid Id, bool trackChanges);
    }
}
