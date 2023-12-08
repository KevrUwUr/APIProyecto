using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDetFacturaCompraService
    {
        IEnumerable<DFacturaCompraDTO> GetAllDetBuyBills(bool trackChanges);

        IEnumerable<DFacturaVentaDTO> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges);
        IEnumerable<DFacturaVentaDTO> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges);

        IEnumerable<DFacturaVentaDTO> GetAllDetBuyBillsForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);
        DFacturaVentaDTO GetDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);

        DFacturaVentaDTO CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DFacturaVentaForCreationDTO facturaCompraProductoForCreation, bool trackChanges);
        void DeleteDetBuyBillForBuyBill(Guid facturaCompraId, Guid productoId, bool trackChanges);
        void UpdateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId,
            DFacturaVentaForUpdateDTO facturaCompraProductoForUpdate, bool perdProdTrackChanges, bool perdTrackChanges, bool prodTrackChanges);
    }
}
