using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFacturaCompraService
    {
        IEnumerable<FacturaCompraDTO> GetAllBuyBills(bool trackChanges);
        FacturaCompraDTO GetBuyBill(Guid Id, bool trackChanges);
        IEnumerable<FacturaCompraDTO> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges);
        FacturaCompraDTO GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        FacturaCompraDTO CreateBuyBillForSupplier(Guid proveedorId, FacturaCompraForCreationDTO facCompraForCreation, bool trackChanges);
        void DeleteBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void UpdateBuyBillForSupplier(Guid proveedorId, Guid id,
            FacturaCompraForUpdateDTO facCompraForUpdate, bool proveedorTrackChanges, bool facCompraTrackChanges);
        (FacturaCompraForUpdateDTO facCompraToPatch, FacturaCompra facCompraEntity) GetFacturaCompraForPatch
            (Guid proveedorId, Guid id, bool proveedorTrackChanges, bool facCompraTrackChanges);
        void SaveChangesForPatch(FacturaCompraForUpdateDTO facCompraToPatch, FacturaCompra facCompraEntity);
    }
}
