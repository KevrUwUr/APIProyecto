using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaCompraRepository
    {
        IEnumerable<FacturaCompra> GetAllBuyBills(bool trackChanges);
        FacturaCompra GetBuyBill(Guid buyBillId, bool trackChanges);
        IEnumerable<FacturaCompra> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges);
        FacturaCompra GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void CreateBuyBillForSupplier(Guid proveedorId, FacturaCompra facCompra);
        void DeleteBuyBill(FacturaCompra facCompra);
    }
}
