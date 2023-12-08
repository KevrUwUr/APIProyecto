using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDetFacturaCompraRepository
    {
        IEnumerable<DetalleFacturaCompra> GetAllDetBuyBills(bool trackChanges);
        IEnumerable<DetalleFacturaCompra> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges);
        IEnumerable<DetalleFacturaCompra> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges);
        DetalleFacturaCompra GetDetBuyBillByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);
        void CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleFacturaCompra detalleFacturaCompra);
        void DeleteDetBuyBill(DetalleFacturaCompra detalleFacturaCompra);
    }
}