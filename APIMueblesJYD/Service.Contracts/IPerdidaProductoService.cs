using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPerdidaProductoService
    {
        IEnumerable<PerdidaProductoDTO> GetAllProductLoses(bool trackChanges);
        PerdidaProductoDTO GetProductLose(Guid Id, bool trackChanges);
    }
}
