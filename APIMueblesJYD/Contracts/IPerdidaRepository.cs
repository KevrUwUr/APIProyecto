using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaRepository
    {
        IEnumerable<UsuarioDTO> GetAllLoses(bool trackChanges);
        UsuarioDTO GetLose(Guid lostId, bool trackChanges);
    }
}
