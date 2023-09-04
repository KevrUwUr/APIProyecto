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
        FacturaCompraDTO GetBuyBill(int Id, bool trackChanges);
    }
}
