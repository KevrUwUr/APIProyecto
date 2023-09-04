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
        IEnumerable<PerdidaProductoDTO> GetAllProductLoses(bool trackChanges);
        PerdidaProductoDTO GetProductLose(int IdPerdidaProducto, bool trackChanges);
    }
}
