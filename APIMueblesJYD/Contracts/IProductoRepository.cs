using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductoRepository
    {
        IEnumerable<ProductoDTO> GetAllProducts(bool trackChanges);
        ProductoDTO GetProduct(int IdProducto, bool trackChanges);
    }
}
