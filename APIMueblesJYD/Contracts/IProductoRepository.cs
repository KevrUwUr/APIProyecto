using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProducts(bool trackChanges);
        Producto GetProduct(Guid productId, bool trackChanges);
    }
}
