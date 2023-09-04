using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductoService
    {
        IEnumerable<ProveedorDTO> GetAllProducts(bool trackChanges);
        ProveedorDTO GetProduct(int Id, bool trackChanges);
    }
}
