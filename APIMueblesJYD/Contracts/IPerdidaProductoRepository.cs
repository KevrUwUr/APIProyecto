using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaProductoRepository
    {
        IEnumerable<UsuarioDTO> GetAllProductLoses(bool trackChanges);
        UsuarioDTO GetProductLose(Guid productLostId, bool trackChanges);
    }
}
