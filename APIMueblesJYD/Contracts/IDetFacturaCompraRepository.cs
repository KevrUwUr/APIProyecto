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
        DetalleFacturaCompra GetDetBuyBill(Guid FacturaCompraId, bool trackChanges);
    }
}