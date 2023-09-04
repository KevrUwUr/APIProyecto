using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProveedorRepository
    {
        IEnumerable<ProveedorDTO> GetAllSuppliers(bool trackChanges);
        ProveedorDTO GetSupplier(int IdProveedor, bool trackChanges);
    }
}
