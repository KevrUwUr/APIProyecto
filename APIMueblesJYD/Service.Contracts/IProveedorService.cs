using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProveedorService
    {
        IEnumerable<ProveedorDTO> GetAllProducts(bool trackChanges);
        ProveedorDTO GetProduct(Guid Id, bool trackChanges);
    }
}
