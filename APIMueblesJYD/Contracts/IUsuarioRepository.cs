using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioDTO> GetAllUsers(bool trackChanges);
        UsuarioDTO GetUser(int usuarioId, bool trackChanges);
    }
}
