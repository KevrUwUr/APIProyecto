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
        IEnumerable<Proveedor> GetAllSuppliers(bool trackChanges);
        Proveedor GetSupplier(Guid IdProveedor, bool trackChanges);
        void CreateSupplier(Proveedor supplier);
        IEnumerable<Proveedor> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteSupplier(Proveedor supplier);
    }
}
