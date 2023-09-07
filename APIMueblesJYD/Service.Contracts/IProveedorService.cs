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
        IEnumerable<ProveedorDTO> GetAllSuppliers(bool trackChanges);
        ProveedorDTO GetSupplier(Guid Id, bool trackChanges);
        ProveedorDTO CreateSupplier(ProveedorForCreationDTO supplier);
        IEnumerable<ProveedorDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<ProveedorDTO> proveedores, string ids) CreateSupplierCollection
            (IEnumerable<ProveedorForCreationDTO> supplierCollection);
        void DeleteSupplier(Guid supplierId, bool trackChanges);
        void UpdateSupplier(Guid supplierId, ProveedorForUpdateDTO supplierForUpdate, bool trackChanges);
    }
}
