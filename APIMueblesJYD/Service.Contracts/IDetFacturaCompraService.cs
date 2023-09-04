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
        DFacturaCompraDTO GetDetBuyBill(int Id, bool trackChanges);
    }
}
