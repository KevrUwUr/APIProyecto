using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaProductoRepository
    {
        IEnumerable<Perdida_Producto> GetAllProductLoses(bool trackChanges);
        Perdida_Producto GetProductLose(Guid productLostId, bool trackChanges);
    }
}
