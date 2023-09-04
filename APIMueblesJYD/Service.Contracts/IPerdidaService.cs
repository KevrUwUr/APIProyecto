using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPerdidaService
    {
        IEnumerable<UsuarioDTO> GetAllLoses(bool trackChanges);
        UsuarioDTO GetLose(int Id, bool trackChanges);
    }
}
